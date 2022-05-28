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
    public class QuestionBussiness : IQuestionBussiness
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionBussiness(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Question> CreateAsync(Question question)
        {
            var questionMap = QuestionMapper.Map(question); 
            var questionRepository = await _questionRepository.CreateAsync(questionMap);
            return QuestionMapper.Map(questionRepository);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Question>> GetAllAsync(Pagination pagination)
        {
            var Questions = await _questionRepository.GetAllAsync(PaginationMapper.Map(pagination));

            //this an example when you need to modify original data, calculations or other acciones
            //Questions.ToList().ForEach(Question =>  {
            //    Question.FirstName = Question.FirstName.ToUpper().Trim();
            //});

            return Questions.Select(QuestionMapper.Map);
        }

        public Task<Question> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Question> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalRecorsdAsync()
        {
            return await _questionRepository.GetTotalRecorsdAsync();
        }

        public Task UpdateAsync(int id, Question Question)
        {
            throw new NotImplementedException();
        }

      
    }
}
