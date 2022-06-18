using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Contracts
{
    public  interface IGenericAccountService<T> where T : class
    {
        Task<AccountResponseDto<T>> CreateAsync(T entity);
        Task<T> LoginAsync(T entity);

        Task LogOutAsync();

        Task ForgotPasswordAsync(T entity);

        Task<bool> ResetPasswordAsync(T entity);

        Task<T> EmailConfirmationAsync(string email, string token);

        Task<T> FindByNameAsync(string email);

        Task<bool> IsEmailConfirmedAsync(T entity);
    }
}
