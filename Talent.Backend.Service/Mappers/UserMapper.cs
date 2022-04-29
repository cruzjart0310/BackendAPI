using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Models;

namespace Talent.Backend.Service.Mappers
{
    public static class UserMapper
    {
        public static User Map(Talent.Backend.Service.Dtos.UserDto user)
        {
            return new User
            {
                Id = new Guid(user.Id.ToString()),
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsMarried = user.IsMarried,
                UserProfile = new UserProfile
                {
                    Id = user.Id,
                },
            };
        }

        public static Talent.Backend.Service.Dtos.UserDto Map(User user)
        {
            return new Dtos.UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsMarried = user.IsMarried,
                UserProfile = new UserProfile
                {
                    Id = user.Id,
                },
            };
        }
    }
}
