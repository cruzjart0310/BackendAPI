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
    public class SurveyRepository : ISurveyRepository
    {
        private readonly EFContext _context;

        public SurveyRepository(EFContext context)
        {
            _context = context;
        }
        public async Task<Survey> CreateAsync(Survey survey)
        {
            await _context.Survey.AddAsync(survey);
            await _context.SaveChangesAsync();
            return survey;
        }

        public Task DeleteAsync(Survey Survey)
        {
            Survey.DeletedAt = DateTime.Now;
            throw new NotImplementedException();
        }

        public void File()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Survey>> GetAllAsync(Pagination pagination)
        {

            var query = await _context.Set<Survey>()
                .Include(x => x.Questions)
                    .ThenInclude(x => x.Type)
                .Include(x => x.Questions)
                    .ThenInclude(x => x.Answers)
                .OrderBy(x => x.Id)
                .AsNoTracking()
                .AsQueryable()
                .Skip((pagination.Page - 1) * pagination.PageZise)
                .Take(pagination.PageZise)
                .ToListAsync();

            return query;
        }

        public async Task<Survey> GetAsync(string id)
        {
            return await _context.Survey
                .Include(x => x.Questions)
                    .ThenInclude(x => x.Type)
                 .Include(x => x.Questions)
                    .ThenInclude(x => x.Answers)
                .AsNoTracking()
                .FirstAsync(x => x.Id == Convert.ToInt32(id));
        }

        public async Task<int> GetTotalRecorsdAsync() => await _context.Survey.CountAsync();

        public Task UpdateAsync(int id, Survey survey)
        {
            survey.UpdatedAt = DateTime.Now;
            throw new NotImplementedException();
        }
    }
}
