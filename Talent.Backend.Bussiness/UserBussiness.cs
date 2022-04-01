using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Contracts;
using Talent.Backend.Bussiness.Mappers;
using Talent.Backend.Bussiness.Models;
using Talent.Backend.DataAccessEF.Contracts;

namespace Talent.Backend.Bussiness
{
    public class UserBussiness : IUserBussiness
    {
        private readonly IUserRepository _userRepository;

        public UserBussiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task CreateUserAsync(User user)
        {
            var userMap = UserMapper.Map(user); 
            await _userRepository.CreateUserAsync(userMap);
        }

        public Task DeleteUserAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllUserAsync(Pagination pagination)
        {
            var users = await _userRepository.GetAllUserAsync(PaginationMapper.Map(pagination));

            //this an example when you need to modify original data, calculations or other acciones
            users.ToList().ForEach(user =>  {
                user.FirstName = user.FirstName.ToUpper().Trim();
            });

            return users.Select(UserMapper.Map);
        }

        public Task<User> GetUserAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateUserAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
