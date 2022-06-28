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
            return UserForRegistrationMapper.Map(userBussiness, true);
        }

        public Task<UserForRegistrationDto> EmailConfirmationAsync(string email, string token)
        {
            throw new NotImplementedException();
        }

        public Task<UserForRegistrationDto> FindByNameAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task ForgotPasswordAsync(UserForRegistrationDto entity)
        {
            throw new NotImplementedException();
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

        public Task LogOutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPasswordAsync(UserForRegistrationDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
