using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Contracts;
using Talent.Backend.Service.Mappers;
using Talent.Backend.Service.Contracts;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly ISurveyBussiness _surveyBussiness;

        public SurveyService(ISurveyBussiness surveyBussiness)
        {
            _surveyBussiness = surveyBussiness; 
        }

        public async Task<SurveyDto> CreateAsync(SurveyDto surveyDto)
        {
            var surveyMap = SurveyMapper.Map(surveyDto);
            var survey = await _surveyBussiness.CreateAsync(surveyMap);
            return SurveyMapper.Map(survey);
        }

        public Task DeleteAsync(SurveyDto surveyDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SurveyDto>> GetAllAsync(PaginationDto paginationDto)
        {
            var surveys = await _surveyBussiness.GetAllAsync(PaginationMapper.Map(paginationDto));

            return surveys.Select(SurveyMapper.Map);
        }

        public async Task<SurveyDto> GetAsync(string id)
        {
            var survey =  await _surveyBussiness.GetAsync(id);
            return SurveyMapper.Map(survey);
        }

        public Task<int> GetTotalRecorsdAsync()
        {
            return _surveyBussiness.GetTotalRecorsdAsync();
        }

        public Task UpdateAsync(int id, SurveyDto SurveyDto)
        {
            throw new NotImplementedException();
        }
    }
}
