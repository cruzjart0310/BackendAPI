using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.DataAccessEF.Contracts;
using Talent.Backend.DataAccessEF.Entities;
using Talent.Backend.DataAccessEF.Extensions;
using Talent.Backend.DataAccessEF.Models;

namespace Talent.Backend.DataAccessEF.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly EFContext _context;

        public QuestionRepository(EFContext context)
        {
            _context = context;
        }
        public async Task<Question> CreateAsync(Question question)
        {
            try
            {
                await _context.Question.AddAsync(question);
                await _context.SaveChangesAsync();
                return question;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Task DeleteAsync(Question Question)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Question>> GetAllAsync(Pagination pagination)
        {
            try
            {
                var query = await _context.Set<Question>()
                    .OrderBy(x => x.Id)
                    .AsNoTracking()
                    .AsQueryable()
                    .Pagination(pagination)
                    .ToListAsync();

                return query;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Task<Question> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalRecorsdAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, Question question)
        {
            throw new NotImplementedException();
        }
    }
}
