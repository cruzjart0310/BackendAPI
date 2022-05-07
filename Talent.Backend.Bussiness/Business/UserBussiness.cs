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

        public async Task<User> CreateAsync(User user)
        {
            var userMap = UserMapper.Map(user); 
            await _userRepository.CreateAsync(userMap);
            return user;
        }

        public Task DeleteAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAllAsync(Pagination pagination)
        {
            var users = await _userRepository.GetAllAsync(PaginationMapper.Map(pagination));

            //this an example when you need to modify original data, calculations or other acciones
            //users.ToList().ForEach(user =>  {
            //    user.FirstName = user.FirstName.ToUpper().Trim();
            //});

            return users.Select(UserMapper.Map);
        }

        public async Task<User> GetAsync(string id)
        {
            var user = await _userRepository.GetAsync(id);

            return UserMapper.Map(user);
        }

        public Task<int> GetTotalRecorsdAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int id, User user)
        {
            throw new NotImplementedException();
        }

      
    }
}
