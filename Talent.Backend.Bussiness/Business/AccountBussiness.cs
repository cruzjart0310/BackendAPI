using System;
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
            return UserRegistrationMapper.Map(userRepository);
        }

        public async Task<AccountResponse<UserForRegistration>> EmailConfirmationAsync(string email, string token)
        {
            var accountRepository = await _accountRepository.EmailConfirmationAsync(email, token);
            return UserRegistrationMapper.Map(accountRepository);
        }

        public Task<UserForRegistration> FindByNameAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountResponse<UserForRegistration>> ForgotPasswordAsync(string email)
        {
            var accountRepository = await _accountRepository.ForgotPasswordAsync(email, "");
            return UserRegistrationMapper.Map(accountRepository);
        }

        public Task<bool> IsEmailConfirmedAsync(UserForRegistration entity)
        {
            throw new NotImplementedException();
        }

        public async Task<TokenRespose<UserForAuthentication>> LoginAsync(UserForAuthentication userForAuthentication)
        {
            var user = UserForAuthenticationMapper.Map(userForAuthentication);
            var userRepository = await _accountRepository.LoginAsync(user);
            return UserForAuthenticationMapper.Map(userRepository);
        }

        public async Task LogOutAsync()
        {
            await _accountRepository.LogOutAsync();
        }

        public Task<bool> ResetPasswordAsync(UserForRegistration entity)
        {
            throw new NotImplementedException();
        }
    }
}
