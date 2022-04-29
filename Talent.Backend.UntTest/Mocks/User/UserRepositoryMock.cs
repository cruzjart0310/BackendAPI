using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.DataAccessEF.Entities;
using Talent.Backend.DataAccessEF.Contracts;

namespace Talent.Backend.UnitTest.Mocks.User
{
    internal class UserRepositoryMock
    {
        public Mock<IUserRepository> _userRepository { get; set; }

        public UserRepositoryMock()
        {
            _userRepository = new Mock<IUserRepository>();
            Setup();
        }

        private void Setup()
        {
            _userRepository.Setup((x) => x.CreateAsync(It.IsAny<Talent.Backend.DataAccessEF.Entities.User>()));
            _userRepository.Setup((x) => x.DeleteAsync(It.IsAny<Talent.Backend.DataAccessEF.Entities.User>())).Returns(Task.Delay(5));
        }
    }
}
