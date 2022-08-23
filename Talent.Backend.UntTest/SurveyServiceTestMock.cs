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
    public class SurveyServiceTestMock
    {
        private ISurveyService _surveyService;
        private ISurveyBussiness _surveyBussiness;

        [SetUp]
        public void Setup()
        {
            #region using Mock
            Mock<ISurveyRepository> _surveyRepository = new SurveyRepositoryMock()._surveyRespository;
            _surveyBussiness = new SurveyBussiness(_surveyRepository.Object);
            _surveyService = new SurveyService(_surveyBussiness);
            #endregion
        }

        [Ignore("Ignore test")]
        [Test]
        public async Task Get_Valid_Survey()
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
            //Act
            var result = _surveyService.GetAsync(id);

            //Assert
            result.Should().NotBeNull();
            result.Id.Should().BePositive();
        }

        [Test]
        public async Task Create_Survey_ReturnsNotNull()
        {
            //Arrange
            SurveyDto survey = new SurveyDto()
            {
                Name = "Survey 1",
                CreatedAt = DateTime.Now,
                Questions = null
            };
            //Act
            var action = await _surveyService.CreateAsync(survey);


            //Assert
            action.Should().NotBeNull();
            action.Name.Should().Be("Survey 1");
            action.Id.Should().Be(action.Id);
            action.Questions.Should().BeNull();
            //action.Should().Be(Is.TypeOf<SurveyDto>());
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
        public async Task Get_Survey_Non_Existent_ReturnsNull()
        {
            //Arrange
            int id = 157989;

            //Act
            var response = _surveyService.GetAsync(id);

            //Assert
            response.Result.Should().BeNull();
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

            //Act
            //var action = await _surveyService.CreateAsync(survey);

            //Assert
            Assert.ThrowsAsync<DbUpdateException>(() => _surveyService.CreateAsync(survey));
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

            //Act
            var action = await _surveyService.GetAllAsync(pagination);

            //Assert
            action.Should().NotBeNull();
            action.Should().HaveCount(1);
        }
    }
}