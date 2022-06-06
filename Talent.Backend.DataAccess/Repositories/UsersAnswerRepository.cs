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
    public class UserAnswerRepository : IUserAnswerRepository
    {
        private readonly EFContext _context;

        public UserAnswerRepository(EFContext context)
        {
            _context = context;
        }
        public async Task<UserAnswer> CreateAsync(UserAnswer userAnswer)
        {
            foreach (var item in userAnswer.Answer)
            {
                var answer = new UserAnswer
                {
                    UserId = userAnswer.User.Id,
                    AnswerId = (int)item.Id,
                    CreatedAt = DateTime.Now,
                };
                await _context.UserAnswer.AddAsync(answer);
                await _context.SaveChangesAsync();
            }
            return userAnswer;
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Survey.SingleAsync(s => s.Id == id);
            _context.Survey.Remove(item);
            _context.Entry(item).Property(x => x.CreatedAt).IsModified = false;
            _context.Entry(item).Property(x => x.UpdatedAt).IsModified = false;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(int id) =>
            await _context.Survey
                .Where(s => s.DeletedAt == null)
                .AnyAsync(x => x.Id == id);

        public async Task<IEnumerable<UserAnswer>> GetAllAsync(Pagination pagination)
        {

            var query = await _context.Set<UserAnswer>()
                .Include(x => x.Answer)
                    .ThenInclude(x => x.Question)
                        .ThenInclude(x => x.Survey)
                .OrderBy(x => x.Id)
                .AsNoTracking()
                .AsQueryable()
                .Skip((pagination.Page - 1) * pagination.PageZise)
                .Take(pagination.PageZise)
                .ToListAsync();

            return query;
        }

        public async Task<UserAnswer> GetAsync(int id)
        {
            var item = await _context.UserAnswer
                .Include(x => x.Answer)
                    .ThenInclude(x => x.Question)
                        .ThenInclude(x => x.Survey)
                .AsNoTracking()
                //.FirstAsync(x => x.Id == Convert.ToInt32(id)); //GetException
                .SingleOrDefaultAsync(x => x.Id == id);

            return item;
        }

        public async Task<int> GetTotalRecorsdAsync() =>
            await _context.UserAnswer
            .CountAsync();

        public async Task UpdateAsync(int id, UserAnswer userAnswer)
        {
            _context.UserAnswer.Update(userAnswer);
            _context.Entry(userAnswer).Property(x => x.CreatedAt).IsModified = false;
            await _context.SaveChangesAsync();
        }
    }
}
