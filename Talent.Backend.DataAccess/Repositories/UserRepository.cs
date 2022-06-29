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
            user.UserProfile = new UserProfile();
            user.UserProfile.Avatar = "avatar.png";
            user.UserProfile.UserId = user.Id;
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
            #region Eager loading
            //var query1 = await _context.Set<User>()
            //    //.Where(x => x.IsMarried)
            //    //.Where(s => s. == null)
            //    .OrderBy(x => x.Id)
            //    .Include(p => p.UserProfile)
            //    .Include(t => t.Teams.Where(t => t.Current == 1)) //.Where(t => t.Current == 1)
            //        .ThenInclude(t => t.TeamAssigned)
            //            .Include(x => x.Teams)
            //               .ThenInclude(x => x.UserResponsible)
            //    .AsNoTracking()
            //    .AsQueryable()
            //    .Skip((pagination.Page - 1) * pagination.PageZise)
            //    .Take(pagination.PageZise)
            //    .ToListAsync();
            #endregion

            #region Select loading
            var query = await _context.Set<User>()
                .OrderBy(x => x.Id)
                .Select(u => new User
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserProfile = new UserProfile
                    {
                        Id = u.UserProfile.Id,
                        Nickname = u.UserProfile.Nickname,
                    },
                    Teams = u.Teams.Select(t => new TeamUser
                    {
                        Current = t.Current,
                        TeamAssigned = new Team
                        {
                            Id = t.TeamAssigned.Id,
                            Name = t.TeamAssigned.Name,
                        },
                        UserResponsible = new User
                        {
                            Id = t.UserResponsible.Id.ToString(),
                            FirstName = t.UserResponsible.FirstName,
                            LastName = t.UserResponsible.LastName,
                        }
                    })//.Where(c => c.Current== 1),
                })
                .AsNoTracking()
                .AsQueryable()
                .Skip((pagination.Page - 1) * pagination.PageZise)
                .Take(pagination.PageZise)
                .ToListAsync();
            #endregion

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

            #region Explicit Loading
            var q = await _context.Set<User>().FirstOrDefaultAsync(u => u.Id == id.ToString());
            await _context.Entry(q).Collection(p => p.Teams).LoadAsync();
            var count = await _context.Entry(q).Collection(p => p.Teams).Query().CountAsync();

            var u = new
            {
                User = q,
                TotalTeams = count,
            };
            #endregion

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
