using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Models;

namespace Talent.Backend.Bussiness.Contracts
{
    public interface IGenericAccountBussiness<T> where T : class
    {
        Task<AccountResponse<T>> CreateAsync(T entity);

        Task<TokenRespose<UserForAuthentication>> LoginAsync(UserForAuthentication userForAuthentication);

        Task LogOutAsync();

        Task ForgotPasswordAsync(T entity);

        Task<bool> ResetPasswordAsync(T entity);

        Task<T> EmailConfirmationAsync(string email, string token);

        Task<T> FindByNameAsync(string email);

        Task<bool> IsEmailConfirmedAsync(T entity);
    }
}
