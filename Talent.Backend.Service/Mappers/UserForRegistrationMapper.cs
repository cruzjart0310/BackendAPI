using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Models;

namespace Talent.Backend.Service.Mappers
{
    public class UserForRegistrationMapper
    {
        public static UserForRegistration Map(Talent.Backend.Service.Dtos.UserForRegistrationDto userForRegistrationDto)
        {
            return new UserForRegistration
            {
                FirstName = userForRegistrationDto.FirstName,
                LastName = userForRegistrationDto.LastName,
                Email = userForRegistrationDto.Email,
                PasswordHash = userForRegistrationDto.Password
            };
        }

        public static Talent.Backend.Service.Dtos.AccountResponseDto<Talent.Backend.Service.Dtos.UserForRegistrationDto> Map(Talent.Backend.Bussiness.Models.AccountResponse<Talent.Backend.Bussiness.Models.UserForRegistration> user)
        {
            return new Talent.Backend.Service.Dtos.AccountResponseDto<Talent.Backend.Service.Dtos.UserForRegistrationDto>
            {
                Element = new Talent.Backend.Service.Dtos.UserForRegistrationDto
                {
                    FirstName = user.Element.FirstName,
                    LastName = user.Element.LastName,
                    Email = user.Element.Email,
                    Password = user.Element.PasswordHash,
                },
                Errors = user.Errors
            };
        }
    }
}
