using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Contracts;
using Talent.Backend.Service.Contracts;
using Talent.Backend.Service.Dtos;
using Talent.Backend.Service.Mappers;

namespace Talent.Backend.Service.Services
{
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly IQuestionTypeBussiness _questionTypeBussiness;

        public QuestionTypeService(IQuestionTypeBussiness questionTypeBussiness)
        {
            _questionTypeBussiness = questionTypeBussiness;
        }

        public async Task<QuestionTypeDto> CreateAsync(QuestionTypeDto questionTypeDto)
        {
            var questionTypeMap = QuestionTypeMapper.Map(questionTypeDto);
            var questionType = await _questionTypeBussiness.CreateAsync(questionTypeMap);
            return QuestionTypeMapper.Map(questionType);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<QuestionTypeDto>> GetAllAsync(PaginationDto paginationDto)
        {
            var questionTypes = await _questionTypeBussiness.GetAllAsync(PaginationMapper.Map(paginationDto));

            return questionTypes.Select(QuestionTypeMapper.Map);
        }

        public Task<QuestionTypeDto> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<QuestionTypeDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalRecorsdAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(QuestionTypeDto questionTypeDto)
        {
            throw new NotImplementedException();
        }
    }
}
