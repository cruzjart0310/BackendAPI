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
                Id = user.Id.ToString(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsMarried = user.IsMarried, 
                UserProfile = new DataAccessEF.Entities.UserProfile
                {
                    Id = new Guid(user.Id.ToString())
                }
            };
        }

        public static Talent.Backend.Bussiness.Models.User Map(User user)
        {
            return new Models.User
            {
                Id = new Guid(user.Id.ToString()),
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsMarried = user.IsMarried, 
                UserProfile = new Models.UserProfile
                {
                    Id = new Guid(user.Id.ToString())
                },
            };
        }
    }
}
