using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Talent.Backend.API.Controllers;
using Talent.Backend.Bussiness;
using Talent.Backend.Bussiness.Contracts;
using Talent.Backend.DataAccessEF;
using Talent.Backend.DataAccessEF.Contracts;
using Talent.Backend.DataAccessEF.Repositories;
using Talent.Backend.Service.Contracts;
using Talent.Backend.Service.Dtos;
using Talent.Backend.Service.Services;
using Talent.Backend.UnitTest.Mocks.Survey;

namespace Talent.Backend.UnitTest
{
    public class SurveyServiceTest
    {
        private EFContext _context;
        private readonly TestBase testBase = new TestBase();

        private ISurveyRepository _surveyRepository;
        private ISurveyService _surveyService;
        private ISurveyBussiness _surveyBussiness;
        private IUriService _uriService;

        [SetUp]
        public void Setup()
        {
            #region using Context
            _context = testBase.BuildContext();
            _surveyRepository = new SurveyRepository(_context);
            _surveyBussiness = new SurveyBussiness(_surveyRepository);
            _surveyService = new SurveyService(_surveyBussiness);
            _uriService = new UriService("https://localhost:44327");
            #endregion
        }

        [Ignore("Ignore test")]
        [Test]
        public async Task Get_Valid_Survey_Using_Mock()
        {
            //Arrange
            int surveyId = 1;

            //Act
            var result = await _surveyService.GetAsync(surveyId);

            //Assertion
            result.Should().NotBeNull();
            result.Name.Should().Be("Survey 1");
            result.Id.Should().Be(1);
        }

        [Test]
        public async Task Get_Valid_Survey_By_Id()
        {
            //Arrange
            int id = 1;
            var controller = new SurveyController(_surveyService, _uriService);

            //Act
            var result = (OkObjectResult)await controller.GetSurvey(id);

            //Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(200);
            result.Value.Should().NotBeNull();
        }

        [Test]
        public async Task Create_Survey__ReturnsStatusCode201()
        {
            //Arrange
            SurveyDto survey = new SurveyDto()
            {
                Name = "Survey 3",
                CreatedAt = DateTime.Now,
                Questions = null
            };
            var controller = new SurveyController(_surveyService, _uriService);

            //Act
            var action = await controller.Create(survey);

            //Assert
            action.Should().NotBeNull();
        }

        [Test]
        public async Task Verify_Specfic_Survey_In_Response()
        {
            //Arrange
            var pagination = new PaginationDto
            {
                PageNumber = 1,
                PageSize = 1
            };

            SurveyDto survey = new SurveyDto()
            {
                Id = 1,
                Name = "Survey 1",
                CreatedAt = DateTime.Now,
                Questions = null
            };

            //Act
            var result = await _surveyService.GetAllAsync(pagination);

            //Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result.Should().Contain(survey);
        }

        [Test]
        public async Task Get_Survey_Non_Existent_ReturnsStatusCode404()
        {
            //Arrange
            int id = 157989 ;
            var controller = new SurveyController(_surveyService, _uriService);

            //Act
            var response = (NotFoundResult)await controller.GetSurvey(id);

            //Assert
            response.Should().NotBeNull();
            response.StatusCode.Should().Be(404);
        }


        [Test]
        public async Task Get_Exception_When_Creating_Survey_With_Empty_Propierties()
        {
            //Arrange
            SurveyDto survey = new SurveyDto()
            {
                Name = null,
                CreatedAt = DateTime.Now,
                Questions = null
            };
            var controller = new SurveyController(_surveyService, _uriService);

            //Act
  
            //Assert
            Assert.ThrowsAsync<DbUpdateException>(() => controller.Create(survey));
        }

        [Test]
        public async Task Get_All_Survey_With_Pagination()
        {
            //Arrange
            var pagination = new PaginationDto
            {
                PageNumber = 1,
                PageSize = 1
            };
            var controller = new SurveyController(_surveyService, _uriService);

            //Act
            var action = await controller.Index(pagination);

            //Assert
            action.Should().NotBeNull();
        }
    }
}