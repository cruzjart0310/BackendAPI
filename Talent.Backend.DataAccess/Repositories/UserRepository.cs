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
    public class UserRepository : IUserRepository
    {
        private readonly EFContext _context;

        public UserRepository(EFContext context)
        {
            _context = context;
        }
        public async Task<User> CreateAsync(User user)
        {
            await _context.ApplicationUsers.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync(Pagination pagination)
        {
            var query = await _context.Set<User>()
                //.Where(x => x.IsMarried)
                .OrderBy(x => x.Id)
                .Include(p => p.UserProfile)
                .Include(t => t.Teams)
                    .ThenInclude(t => t.TeamAssigned)
                        .Include(x => x.Teams)
                           .ThenInclude(x => x.UserResponsible)
                .AsNoTracking()
                .AsQueryable()
                .Skip((pagination.Page - 1) * pagination.PageZise)
                .Take(pagination.PageZise)
                .ToListAsync();

            return query;
        }

        public async Task<User> GetAsync(int id)
        {

            var user = await _context.Users
                .Include(p => p.UserProfile)
                .Include(t => t.Teams.Where(x => x.Current == 1))
                    .ThenInclude(ta => ta.TeamAssigned)
                        .Include(x => x.Teams)
                           .ThenInclude(x => x.UserResponsible)
                 .AsNoTracking()
                 .SingleOrDefaultAsync(x => x.Id == id.ToString());

            return user;

        }

        public Task<int> GetTotalRecorsdAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
