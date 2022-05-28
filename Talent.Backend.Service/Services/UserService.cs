using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Contracts;
using Talent.Backend.Service.Mappers;
using Talent.Backend.Service.Contracts;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserBussiness _userBussiness;

        public UserService(IUserBussiness userBussiness)
        {
            _userBussiness = userBussiness; 
        }

        public async Task<UserDto> CreateAsync(UserDto userDto)
        {
            var userMap = UserMapper.Map(userDto);
            await _userBussiness.CreateAsync(userMap);

            return userDto;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync(PaginationDto paginationDto)
        {
            var users = await _userBussiness.GetAllAsync(PaginationMapper.Map(paginationDto));

            return users.Select(UserMapper.Map);
        }

        public async Task<UserDto> GetAsync(int id)
        {
            var user = await _userBussiness.GetAsync(id);
            return UserMapper.Map(user);
        }

        public Task<int> GetTotalRecorsdAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }
}
