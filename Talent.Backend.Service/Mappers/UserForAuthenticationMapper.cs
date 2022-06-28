using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Models;

namespace Talent.Backend.Service.Mappers
{
    public class UserForAuthenticationMapper
    {
        public static UserForAuthentication Map(Talent.Backend.Service.Dtos.UserForAuthenticationDto userForAuthenticationDto)
        {
            return new UserForAuthentication
            {
                Email = userForAuthenticationDto.Email,
                Password = userForAuthenticationDto.Password,
                ClientUri = userForAuthenticationDto.ClientUri,
            };
        }

        public static Talent.Backend.Service.Dtos.LoginResposeDto<Talent.Backend.Service.Dtos.UserForAuthenticationDto> Map(Talent.Backend.Bussiness.Models.TokenRespose<Talent.Backend.Bussiness.Models.UserForAuthentication> tokenResponse)
        {
            if (tokenResponse == null)
                return null;

            return new Talent.Backend.Service.Dtos.LoginResposeDto<Talent.Backend.Service.Dtos.UserForAuthenticationDto>
            {
                Element = null,
                Token = tokenResponse.Token,
                Expiration = tokenResponse.Expiration,
                Errors = tokenResponse.Errors,
            };
        }
    }
}
