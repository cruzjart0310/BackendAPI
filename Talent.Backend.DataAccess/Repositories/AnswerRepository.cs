using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.DataAccessEF.Contracts;
using Talent.Backend.DataAccessEF.Entities;
using Talent.Backend.DataAccessEF.Models;

namespace Talent.Backend.DataAccessEF.Repositories
{
    public class AnswerRepository : IAnswerRepository
    {
        private readonly EFContext _context;

        public AnswerRepository(EFContext context)
        {
            _context = context;
        }
        public async Task<Answer> CreateAsync(Answer answer)
        {
            answer.Question = null;
            answer.CreatedAt = DateTime.Now;
            await _context.Answers.AddAsync(answer);
            await _context.SaveChangesAsync();
            return answer;
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
            var query = await _context.Set<Answer>()
                .Include(q => q.Question)
                .OrderBy(x => x.Id)
                .AsNoTracking()
                .AsQueryable()
                .Skip((pagination.Page - 1) * pagination.PageZise)
                .Take(pagination.PageZise)
                .ToListAsync();

            return query;
        }

        public Task<Answer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetTotalRecorsdAsync()
        {
            return await _context.Answers.CountAsync();
        }

        public Task UpdateAsync(Answer Answer)
        {
            throw new NotImplementedException();
        }
    }
}
