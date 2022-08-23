using System.Threading.Tasks;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Contracts
{
    public interface IGenericAccountService<T> where T : class
    {
        Task<AccountResponseDto<T>> CreateAsync(T entity);
        Task<LoginResposeDto<UserForAuthenticationDto>> LoginAsync(UserForAuthenticationDto entity);

        Task LogOutAsync();

        Task<AccountResponseDto<T>> ForgotPasswordAsync(string email);

        Task<bool> ResetPasswordAsync(T entity);

        Task<AccountResponseDto<T>> EmailConfirmationAsync(string email, string token);

        Task<T> FindByNameAsync(string email);

        Task<bool> IsEmailConfirmedAsync(T entity);
    }
}
