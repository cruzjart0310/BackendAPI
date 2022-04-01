using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllUserAsync(PaginationDto paginationDto);
        Task<UserDto> GetUserAsync(string id);
        Task CreateUserAsync(UserDto UserDto);
        Task UpdateUserAsync(UserDto UserDto);
        Task DeleteUserAsync(UserDto UserDto);
    }
}
