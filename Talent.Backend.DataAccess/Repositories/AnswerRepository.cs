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
    public class AnswerRepository : IAnswerRepository
    {
        private readonly EFContext _context;

        public AnswerRepository(EFContext context)
        {
            _context = context;
        }
        public async Task<Answer> CreateAsync(Answer Answer)
        {
            try
            {
                await _context.Answer.AddAsync(Answer);
                await _context.SaveChangesAsync();
                return Answer;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Task DeleteAsync(Answer Answer)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Answer>> GetAllAsync(Pagination pagination)
        {
            try
            {
                var query = await _context.Set<Answer>()
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

        public Task<Answer> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, Answer Answer)
        {
            throw new NotImplementedException();
        }
    }
}
