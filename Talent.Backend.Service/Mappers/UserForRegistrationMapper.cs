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
                PasswordHash = userForRegistrationDto.PasswordHash
            };
        }

        public static Talent.Backend.Service.Dtos.UserForRegistrationDto Map(UserForRegistration user)
        {
            return new Talent.Backend.Service.Dtos.UserForRegistrationDto
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = user.PasswordHash
            };
        }

        public static Talent.Backend.Service.Dtos.AccountResponseDto<Talent.Backend.Service.Dtos.UserForRegistrationDto> Map(Talent.Backend.Bussiness.Models.AccountResponse<Talent.Backend.Bussiness.Models.UserForRegistration> user, bool isFromBussiness)
        {
            return new Talent.Backend.Service.Dtos.AccountResponseDto<Talent.Backend.Service.Dtos.UserForRegistrationDto>
            {
                Element = new Talent.Backend.Service.Dtos.UserForRegistrationDto
                {
                    FirstName = user.Element.FirstName,
                    LastName = user.Element.LastName,
                    Email = user.Element.Email,
                    PasswordHash = user.Element.PasswordHash,
                },
                Errors = user.Errors
            };
        }
    }
}
