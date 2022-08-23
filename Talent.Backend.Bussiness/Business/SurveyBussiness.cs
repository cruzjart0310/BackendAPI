using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Contracts;
using Talent.Backend.Bussiness.Mappers;
using Talent.Backend.Bussiness.Models;
using Talent.Backend.DataAccessEF.Contracts;

namespace Talent.Backend.Bussiness
{
    public class SurveyBussiness : ISurveyBussiness
    {
        private readonly ISurveyRepository _surveyRepository;

        public SurveyBussiness(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        public async Task<Survey> CreateAsync(Survey survey)
        {
            var surveyMap = SurveyMapper.Map(survey);
            var surveyRepository = await _surveyRepository.CreateAsync(surveyMap);
            return SurveyMapper.Map(surveyRepository);
        }

        public async Task DeleteAsync(int id)
        {
            await _surveyRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistAsync(int id) => await _surveyRepository.ExistAsync(id);

        public async Task<IEnumerable<Survey>> GetAllAsync(Pagination pagination)
        {
            var surveys = await _surveyRepository.GetAllAsync(PaginationMapper.Map(pagination));

            //this an example when you need to modify original data, calculations or another actions
            //Surveys.ToList().ForEach(Survey =>  {
            //    Survey.FirstName = Survey.FirstName.ToUpper().Trim();
            //});

            return surveys.Select(SurveyMapper.Map);
        }

        public async Task<Survey> GetAsync(int id)
        {
            var survey = await _surveyRepository.GetAsync(id);

            return SurveyMapper.Map(survey);
        }

        public Task<int> GetTotalRecorsdAsync() => _surveyRepository.GetTotalRecorsdAsync();

        public async Task UpdateAsync(Survey survey)
        {
            var surveyMap = SurveyMapper.Map(survey);
            await _surveyRepository.UpdateAsync(surveyMap);
        }
    }
}
