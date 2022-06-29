using System;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Contracts;
using Talent.Backend.Service.Contracts;
using Talent.Backend.Service.Dtos;
using Talent.Backend.Service.Mappers;

namespace Talent.Backend.Service.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountBussiness _accountBussiness;

        public AccountService(IAccountBussiness accounBussiness)
        {
            _accountBussiness = accounBussiness; 
        }

        public async Task<AccountResponseDto<UserForRegistrationDto>> CreateAsync(UserForRegistrationDto userDto)
        {
            var userMap = UserForRegistrationMapper.Map(userDto);
            var userBussiness = await _accountBussiness.CreateAsync(userMap);
            return UserForRegistrationMapper.Map(userBussiness);
        }

        public async Task<AccountResponseDto<UserForRegistrationDto>> EmailConfirmationAsync(string email, string token)
        {
            var userBussiness = await _accountBussiness.EmailConfirmationAsync(email, token);
            return UserForRegistrationMapper.Map(userBussiness);
        }

        public Task<UserForRegistrationDto> FindByNameAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<AccountResponseDto<UserForRegistrationDto>> ForgotPasswordAsync(string email)
        {
            var userBussiness = await _accountBussiness.ForgotPasswordAsync(email);
            return UserForRegistrationMapper.Map(userBussiness);
        }

        public Task<bool> IsEmailConfirmedAsync(UserForRegistrationDto entity)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginResposeDto<UserForAuthenticationDto>> LoginAsync(UserForAuthenticationDto entity)
        {
            var map = UserForAuthenticationMapper.Map(entity);
            var userLogin = await  _accountBussiness.LoginAsync(map);
            return UserForAuthenticationMapper.Map(userLogin);
        }

        public async Task LogOutAsync()
        {
            await _accountBussiness.LogOutAsync();
        }

        public Task<bool> ResetPasswordAsync(UserForRegistrationDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
