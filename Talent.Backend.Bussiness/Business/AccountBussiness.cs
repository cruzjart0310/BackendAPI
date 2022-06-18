using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Contracts;
using Talent.Backend.Bussiness.Mappers;
using Talent.Backend.Bussiness.Models;
using Talent.Backend.DataAccessEF.Contracts;

namespace Talent.Backend.Bussiness
{
    public class AccountBussiness : IAccountBussiness
    {
        private readonly IAccountRepository _accountRepository;

        public AccountBussiness(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<AccountResponse<UserForRegistration>> CreateAsync(UserForRegistration user)
        {
            var userMap = UserRegistrationMapper.Map(user); 
            var userRepository = await _accountRepository.CreateAsync(userMap);

            return UserRegistrationMapper.Map(userRepository, true);
        }

        public Task<UserForRegistration> EmailConfirmationAsync(string email, string token)
        {
            throw new NotImplementedException();
        }

        public Task<UserForRegistration> FindByNameAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task ForgotPasswordAsync(UserForRegistration entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsEmailConfirmedAsync(UserForRegistration entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserForRegistration> LoginAsync(UserForRegistration entity)
        {
            var user = UserRegistrationMapper.Map(entity);

            return null;
        }

        public Task LogOutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPasswordAsync(UserForRegistration entity)
        {
            throw new NotImplementedException();
        }
    }
}
