using System.Collections.Generic;
using System.Linq;
using Talent.Backend.Bussiness.Models;
using Talent.Backend.DataAccessEF.Entities;

namespace Talent.Backend.Bussiness.Mappers
{
    public static class UserForAuthenticationMapper
    {
        public static Talent.Backend.DataAccessEF.Models.UserForAuthentication Map(Talent.Backend.Bussiness.Models.UserForAuthentication userForAuthentication)
        {
            if (userForAuthentication == null)
                return null;

            return new Talent.Backend.DataAccessEF.Models.UserForAuthentication
            {
                Email = userForAuthentication.Email,
                Password = userForAuthentication.Password,  
                ClientUri = userForAuthentication.ClientUri,
            };
        }

        public static Talent.Backend.Bussiness.Models.TokenRespose<UserForAuthentication> Map(Talent.Backend.DataAccessEF.Models.TokenRespose<Talent.Backend.DataAccessEF.Entities.User> tokenResponse)
        {
            if (tokenResponse == null)
                return null;

            return new Talent.Backend.Bussiness.Models.TokenRespose<UserForAuthentication>
            {
                Element = null,
                Token = tokenResponse.Token,
                Expiration = tokenResponse.Expiration,
                Errors = tokenResponse.Errors,
            };
        }
    }
}
