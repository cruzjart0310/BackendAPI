using Moq;
using System.Threading.Tasks;
using Talent.Backend.DataAccessEF.Contracts;
using Talent.Backend.UnitTest.Stubs;

namespace Talent.Backend.UnitTest.Mocks.Survey
{
    public class SurveyRepositoryMock
    {
        public Mock<ISurveyRepository> _surveyRespository { get; set; }

        public SurveyRepositoryMock()
        {
            _surveyRespository = new Mock<ISurveyRepository>();
            Setup();
        }

        private void Setup()
        {
            _surveyRespository
                .Setup((x) => x.CreateAsync(It.IsAny<Talent.Backend.DataAccessEF.Entities.Survey>()))
                .ReturnsAsync(SurveyStub.survey_1);

            _surveyRespository
                .Setup((x) => x.DeleteAsync(It.Is<int>(p => p.Equals(3))))
                .Returns(Task.Delay(5));

            _surveyRespository
                .Setup((x) => x.DeleteAsync(It.Is<int>(p => !p.Equals(3))))
                .Returns(Task.Delay(5));

            _surveyRespository
                .Setup((x) => x.ExistAsync(It.Is<int>(p => p.Equals(3))))
                .ReturnsAsync(true);

            _surveyRespository
                .Setup((x) => x.GetAsync(It.Is<int>(p => p.Equals(1))))
                .ReturnsAsync(SurveyStub.survey_1);

            _surveyRespository
                .Setup((x) => x.GetAllAsync(SurveyStub.pagination))
                .ReturnsAsync(SurveyStub.surveyList);

            _surveyRespository
                .Setup((x) => x.UpdateAsync(It.IsAny<Talent.Backend.DataAccessEF.Entities.Survey>()))
                .Returns(Task.Delay(5));
        }
    }
}
