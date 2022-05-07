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
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionBussiness _questionBussiness;

        public QuestionService(IQuestionBussiness questionBussiness)
        {
            _questionBussiness = questionBussiness; 
        }

        public async Task<QuestionDto> CreateAsync(QuestionDto QuestionDto)
        {
            var QuestionMap = QuestionMapper.Map(QuestionDto);
            var Question = await _questionBussiness.CreateAsync(QuestionMap);
            return QuestionMapper.Map(Question);
        }

        public Task DeleteAsync(QuestionDto QuestionDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<QuestionDto>> GetAllAsync(PaginationDto paginationDto)
        {
            var Questions = await _questionBussiness.GetAllAsync(PaginationMapper.Map(paginationDto));

            return Questions.Select(QuestionMapper.Map);
        }

        public Task<QuestionDto> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalRecorsdAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, QuestionDto QuestionDto)
        {
            throw new NotImplementedException();
        }
    }
}
