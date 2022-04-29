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
            try
            {
                await _context.Survey.AddAsync(survey);
                await _context.SaveChangesAsync();
                return survey;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Task DeleteAsync(Survey Survey)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Survey>> GetAllAsync(Pagination pagination)
        {
            try
            {
                var query = await _context.Set<Survey>()
                    //.Include(x => x.Questions)
                    //    .ThenInclude(x => x.Type)
                    //.Include(x => x.Questions)
                    //    .ThenInclude(x => x.Answers)
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

        public async Task<Survey> GetAsync(int id)
        {
            try
            {
                return await _context.Survey
                    .Include(x => x.Questions)
                        .ThenInclude(x => x.Type)
                     .Include(x => x.Questions)
                        .ThenInclude(x => x.Answers)
                    .AsNoTracking()
                    .FirstAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            };
        }

        public Task UpdateAsync(int id, Survey survey)
        {
            throw new NotImplementedException();
        }
    }
}
