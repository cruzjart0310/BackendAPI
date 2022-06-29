
using Talent.Backend.DataAccessEF.Entities;
using Talent.Backend.DataAccessEF.Models;

namespace Talent.Backend.Bussiness.Mappers
{
    public static class UserRegistrationMapper
    {
        public static User Map(Talent.Backend.Bussiness.Models.UserForRegistration user)
        {
            return new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                UserName = user.Email
            };
        }

        public static Talent.Backend.Bussiness.Models.AccountResponse<Talent.Backend.Bussiness.Models.UserForRegistration> Map(AccountResponse<User> user)
        {
            return new Talent.Backend.Bussiness.Models.AccountResponse<Talent.Backend.Bussiness.Models.UserForRegistration>
            {
                Element = new Talent.Backend.Bussiness.Models.UserForRegistration
                {
                    FirstName = user?.Element?.FirstName,
                    LastName = user?.Element?.LastName,
                    Email = user?.Element?.Email,
                    PasswordHash = user?.Element?.PasswordHash,
                },
                Errors = user?.Errors,

            };
        }
    }
}
