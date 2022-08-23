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
            if (userAnswer == null) return null;

            foreach (var item in userAnswer.Answers)
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
            var item = await _context.Surveys.SingleAsync(s => s.Id == id);
            _context.Surveys.Remove(item);
            _context.Entry(item).Property(x => x.CreatedAt).IsModified = false;
            _context.Entry(item).Property(x => x.UpdatedAt).IsModified = false;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistAsync(int id) =>
            await _context.Surveys
                .Where(s => s.DeletedAt == null)
                .AnyAsync(x => x.Id == id);

        public async Task<IEnumerable<UserAnswer>> GetAllAsync(Pagination pagination)
        {

            var query = await _context.Set<UserAnswer>()
                .Include(x => x.Answers)
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

        public async Task<UserPointResponse<User>> GetPointsAsync(string userId, int surveyId)
        {
            var user = await _context.Users.FindAsync(userId);

            double percentage = 100.0;
            int totalQuestions = await _context.Questions
                .Include(x => x.Survey)
                .Where(x => x.SurveyId == surveyId)
                .CountAsync();

            int totalCorrectAnswers = await (from ua in _context.UserAnswer
                                             join a in _context.Answers on ua.AnswerId equals a.Id
                                             join q in _context.Questions on a.QuestionId equals q.Id
                                             where q.SurveyId == surveyId
                                             where a.IsCorrect == 1
                                             where ua.UserId == userId
                                             select new { Id = a.Id })
                .CountAsync();

            double questionValue = (percentage / totalQuestions) * 1.0;
            double totalPoint = (totalCorrectAnswers * questionValue);

            return new UserPointResponse<User>
            {
                Element = user,
                Points = totalPoint
            };
        }

        public async Task<UserAnswer> GetAsync(int id)
        {
            var item = await _context.UserAnswer
                .Include(x => x.Answers)
                    .ThenInclude(x => x.Question)
                        .ThenInclude(x => x.Survey)
                .AsNoTracking()
                //.FirstAsync(x => x.Id == Convert.ToInt32(id)); //GetException
                .SingleOrDefaultAsync(x => x.Id == id);

            var totalQuestions = await _context.Surveys
                .Include(x => x.Questions.Where(x => x.SurveyId == 1))
                .CountAsync();

            return item;
        }

        public async Task<int> GetTotalRecorsdAsync() =>
            await _context.UserAnswer
            .CountAsync();

        public async Task UpdateAsync(UserAnswer userAnswer)
        {
            _context.UserAnswer.Update(userAnswer);
            _context.Entry(userAnswer).Property(x => x.CreatedAt).IsModified = false;
            await _context.SaveChangesAsync();
        }
    }
}
