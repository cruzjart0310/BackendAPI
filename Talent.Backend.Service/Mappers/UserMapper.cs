using System.Linq;
using Talent.Backend.Bussiness.Models;

namespace Talent.Backend.Service.Mappers
{
    public static class UserMapper
    {
        public static User Map(Talent.Backend.Service.Dtos.UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id.ToString(),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                //IsMarried = user.IsMarried,
                UserProfile = new UserProfile
                {
                    Id = userDto.Id,
                },
                Teams = userDto.Teams.Select(t => new TeamUser
                {
                    Current = t.Current,
                    TeamAssigned = new Team
                    {
                        Id = t.TeamAssigned.Id,
                        Name = t.TeamAssigned.Name,
                    },
                    //User = new User
                    //{
                    //    FirstName = t.User.FirstName,
                    //    LastName = t.User.LastName,
                    //},
                    UserResponsible = new User
                    {
                        FirstName = t.UserResponsible.FirstName,
                        LastName = t.UserResponsible.LastName,
                    }

                }),
            };
        }

        public static Talent.Backend.Service.Dtos.UserDto Map(User user)
        {
            return new Dtos.UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserProfile = new Dtos.UserProfileDto
                {
                    Nickname = user.UserProfile.Nickname,
                    Avatar = user.UserProfile.Avatar,
                },
                Teams = user.Teams.Select(t => new Dtos.TeamUserDto
                {
                    Current = t.Current,
                    TeamAssigned = new Dtos.TeamDto
                    {
                        Id = t.TeamAssigned.Id,
                        Name = t.TeamAssigned.Name,
                    },
                    //User = new Dtos.UserAssignedDto
                    //{

                    //    FirstName = t.User.FirstName,
                    //    LastName = t.User.LastName,
                    //},
                    UserResponsible = new Dtos.UserResponsibleDto
                    {
                        FirstName = t.UserResponsible.FirstName,
                        LastName = t.UserResponsible.LastName,
                    }
                }),
            };
        }

        public static User Map(Talent.Backend.Service.Dtos.UserForRegistrationDto userDto, bool isFromService)
        {
            return new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password
            };
        }

        public static Talent.Backend.Service.Dtos.UserForRegistrationDto Map(User user, bool isFromBussiness)
        {
            return new Talent.Backend.Service.Dtos.UserForRegistrationDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password
            };
        }
    }
}
