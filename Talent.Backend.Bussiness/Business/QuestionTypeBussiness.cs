using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Contracts;
using Talent.Backend.Bussiness.Mappers;
using Talent.Backend.Bussiness.Models;
using Talent.Backend.DataAccessEF.Contracts;

namespace Talent.Backend.Bussiness
{
    public class QuestionTypeBussiness : IQuestionTypeBussiness
    {
        private readonly IQuestionTypeRepository _questionTypeRepository;

        public QuestionTypeBussiness(IQuestionTypeRepository surveyRepository)
        {
            _questionTypeRepository = surveyRepository;
        }

        public async Task<QuestionType> CreateAsync(QuestionType questionType)
        {
            var questionTypeMap = QuestionTypeMapper.Map(questionType);
            var questionTypeRepository = await _questionTypeRepository.CreateAsync(questionTypeMap);
            return QuestionTypeMapper.Map(questionTypeRepository);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<QuestionType>> GetAllAsync(Pagination pagination)
        {
            var questionsType = await _questionTypeRepository.GetAllAsync(PaginationMapper.Map(pagination));

            //this an example when you need to modify original data, calculations or another actions
            //Surveys.ToList().ForEach(Survey =>  {
            //    Survey.FirstName = Survey.FirstName.ToUpper().Trim();
            //});

            return questionsType.Select(QuestionTypeMapper.Map);
        }

        public async Task<QuestionType> GetAsync(int id)
        {
            var questionType = await _questionTypeRepository.GetAsync(id);

            return QuestionTypeMapper.Map(questionType);
        }

        public Task<int> GetTotalRecorsdAsync() => _questionTypeRepository.GetTotalRecorsdAsync();

        public Task UpdateAsync(QuestionType questionType)
        {
            throw new NotImplementedException();
        }


    }
}
