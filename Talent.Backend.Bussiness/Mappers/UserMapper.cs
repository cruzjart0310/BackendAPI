using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.DataAccessEF.Entities;

namespace Talent.Backend.Bussiness.Mappers
{
    public static class UserMapper
    {
        public static User Map(Talent.Backend.Bussiness.Models.User user)
        {
            return new User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsMarried = user.IsMarried,
                UserProfile = new DataAccessEF.Entities.UserProfile
                {
                    Id = new Guid(user.Id.ToString())
                },
                Teams = user.Teams.Select(t => new TeamUser
                {
                    Current = t.Current,
                    TeamAssigned = new Team
                    {
                        Id = t.TeamAssigned.Id,
                        Name = t.TeamAssigned.Name,
                    },
                    //User = new User
                    //{
                    //    Id = t.User.Id.ToString(),
                    //    FirstName = t.User.FirstName,   
                    //    LastName= t.User.LastName,  
                    //},
                    UserResponsible = new User
                    {
                        Id = t.UserResponsible.Id.ToString(),
                        FirstName = t.UserResponsible.FirstName,
                        LastName = t.UserResponsible.LastName,
                    }
                }),
                
            };
        }

        public static Talent.Backend.Bussiness.Models.User Map(User user)
        {
            return new Models.User
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsMarried = user.IsMarried, 
                UserProfile = new Models.UserProfile
                {
                    Id = user.Id.ToString()
                },
                Teams = user.Teams.Select(t => new Talent.Backend.Bussiness.Models.TeamUser
                {
                    Current = t.Current,
                    TeamAssigned = new Talent.Backend.Bussiness.Models.Team
                    {
                        Id = t.TeamAssigned.Id,
                        Name = t.TeamAssigned.Name,
                    },
                    //User = new Talent.Backend.Bussiness.Models.User
                    //{
                    //    Id = t.User.Id,
                    //    FirstName = t.User.FirstName,
                    //    LastName = t.User.LastName,
                    //},
                    UserResponsible = new Talent.Backend.Bussiness.Models.User
                    {
                        Id = t.UserResponsible.Id.ToString(),
                        FirstName = t.UserResponsible.FirstName,
                        LastName = t.UserResponsible.LastName,
                    }
                }),
            };
        }
    }
}
