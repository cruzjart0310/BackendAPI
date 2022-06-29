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
            question.Type = null;
            question.Survey = null;
            question.CreatedAt = DateTime.Now;
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
            return question;
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
            var query = await _context.Set<Question>()
                .Include(t => t.Type)
                .Include(s => s.Survey)
                .OrderBy(x => x.Id)
                .AsNoTracking()
                .AsQueryable()
                .Skip((pagination.Page - 1) * pagination.PageZise)
                .Take(pagination.PageZise)
                .ToListAsync();

            return query;
        }

        public Task<Question> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalRecorsdAsync()
        {
            return await _context.Questions.CountAsync();
        }

        public Task UpdateAsync(int id, Question question)
        {
            throw new NotImplementedException();
        }
    }
}
