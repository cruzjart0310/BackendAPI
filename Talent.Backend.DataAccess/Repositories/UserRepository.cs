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
            try
            {
                await _context.ApplicationUsers.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync(Pagination pagination)
        {
            try
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
                    .Pagination(pagination)
                    .ToListAsync();

                return query;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<User> GetAsync(string id)
        {
            try
            {
                var user = await _context.Users
                    .Include(p => p.UserProfile)
                    .Include(t => t.Teams.Where(x => x.Current == 1))
                        .ThenInclude(ta => ta.TeamAssigned)
                            .Include(x => x.Teams)
                               .ThenInclude(x => x.UserResponsible)
                     .AsNoTracking()
                     .SingleOrDefaultAsync(x => x.Id == id );

                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
