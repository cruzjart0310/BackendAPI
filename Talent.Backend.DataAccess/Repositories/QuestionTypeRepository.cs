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
    public class QuestionTypeRepository : IQuestionTypeRepository
    {
        private readonly EFContext _context;

        public QuestionTypeRepository(EFContext context)
        {
            _context = context;
        }
        public async Task<QuestionType> CreateAsync(QuestionType questionType)
        {
            questionType.CreatedAt = DateTime.Now;
            await _context.QuestionTypes.AddAsync(questionType);
            await _context.SaveChangesAsync();
            return questionType;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<QuestionType>> GetAllAsync(Pagination pagination)
        {

            var query = await _context.Set<QuestionType>()
                .OrderBy(x => x.Id)
                .AsNoTracking()
                .AsQueryable()
                .Pagination(pagination)
                .ToListAsync();

            return query;

        }

        public Task<QuestionType> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetTotalRecorsdAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, QuestionType questionType)
        {
            throw new NotImplementedException();
        }
    }
}
