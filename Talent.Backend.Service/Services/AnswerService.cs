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
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerBussiness _answerBussiness;

        public AnswerService(IAnswerBussiness answerBussiness)
        {
            _answerBussiness = answerBussiness; 
        }

        public async Task<AnswerDto> CreateAsync(AnswerDto answerDto)
        {
            var answerMap = AnswerMapper.Map(answerDto);
            var answers = await _answerBussiness.CreateAsync(answerMap);
            return AnswerMapper.Map(answers);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AnswerDto>> GetAllAsync(PaginationDto paginationDto)
        {
            var answers = await _answerBussiness.GetAllAsync(PaginationMapper.Map(paginationDto));

            return answers.Select(AnswerMapper.Map);
        }

        public Task<AnswerDto> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalRecorsdAsync()
        {
            return await _answerBussiness.GetTotalRecorsdAsync();
        }

        public Task UpdateAsync(int id, AnswerDto answerDto)
        {
            throw new NotImplementedException();
        }
    }
}
