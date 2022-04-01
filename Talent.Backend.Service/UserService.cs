using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Contracts;
using Talent.Backend.Service.Mappers;
using Talent.Backend.Service.Contracts;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service
{
    public class UserService : IUserService
    {
        private readonly IUserBussiness _userBussiness;

        public UserService(IUserBussiness userBussiness)
        {
            _userBussiness = userBussiness; 
        }

        public async Task CreateUserAsync(UserDto UserDto)
        {
            var userMap = UserMapper.Map(UserDto);
            await _userBussiness.CreateUserAsync(userMap);
        }

        public Task DeleteUserAsync(UserDto UserDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetAllUserAsync(PaginationDto paginationDto)
        {
            var users = await _userBussiness.GetAllUserAsync(PaginationMapper.Map(paginationDto));

            return users.Select(UserMapper.Map);
        }

        public Task<UserDto> GetUserAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(UserDto UserDto)
        {
            throw new NotImplementedException();
        }
    }
}
