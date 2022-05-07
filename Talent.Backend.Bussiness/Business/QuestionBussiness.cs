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
        private readonly IQuestionRepository _QuestionRepository;

        public QuestionBussiness(IQuestionRepository questionRepository)
        {
            _QuestionRepository = questionRepository;
        }

        public async Task<Question> CreateAsync(Question question)
        {
            var questionMap = QuestionMapper.Map(question); 
            var questionRepository = await _QuestionRepository.CreateAsync(questionMap);
            return QuestionMapper.Map(questionRepository);
        }

        public Task DeleteAsync(Question Question)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Question>> GetAllAsync(Pagination pagination)
        {
            var Questions = await _QuestionRepository.GetAllAsync(PaginationMapper.Map(pagination));

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

        public Task<int> GetTotalRecorsdAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, Question Question)
        {
            throw new NotImplementedException();
        }

      
    }
}
