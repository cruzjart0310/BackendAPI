﻿using System.Threading.Tasks;
using Talent.Backend.DataAccessEF.Models;

namespace Talent.Backend.DataAccessEF.Contracts
{
    public interface IGenericAccountRepository<T> where T : class
    {
        Task<AccountResponse<T>> CreateAsync(T entity);
        Task<TokenRespose<T>> LoginAsync(UserForAuthentication userForAuthentication);

        Task LogOutAsync();

        Task<AccountResponse<T>> ForgotPasswordAsync(string email, string clientUrl);

        Task<AccountResponse<T>> ResetPasswordAsync(ResetPassword entity);

        Task<AccountResponse<T>> EmailConfirmationAsync(string email, string token);

        Task<T> FindByNameAsync(string email);

        Task<AccountResponse<T>> EmailConfirmedAsync(string email, string token);
    }
}
