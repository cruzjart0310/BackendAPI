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
    public class AnswerBussiness : IAnswerBussiness
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerBussiness(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<Answer> CreateAsync(Answer answer)
        {
            var answwerMap = AnswerMapper.Map(answer);
            var questionRepository = await _answerRepository.CreateAsync(answwerMap);
            return AnswerMapper.Map(questionRepository);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Answer>> GetAllAsync(Pagination pagination)
        {
            var Questions = await _answerRepository.GetAllAsync(PaginationMapper.Map(pagination));

            //this an example when you need to modify original data, calculations or other acciones
            //Questions.ToList().ForEach(Question =>  {
            //    Question.FirstName = Question.FirstName.ToUpper().Trim();
            //});

            return Questions.Select(AnswerMapper.Map);
        }

        public Task<Answer> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Answer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalRecorsdAsync()
        {
            return await _answerRepository.GetTotalRecorsdAsync();
        }

        public Task UpdateAsync(Answer answer)
        {
            throw new NotImplementedException();
        }


    }
}
