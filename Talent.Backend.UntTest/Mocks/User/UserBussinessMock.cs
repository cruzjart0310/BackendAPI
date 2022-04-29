using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Contracts;

namespace Talent.Backend.UnitTest.Mocks.User
{
    internal class UserBussinessMock
    {
        public Mock<IUserBussiness> userBussiness { get; set; }

        public UserBussinessMock()
        {
            userBussiness = new Mock<IUserBussiness>();
            Setup();
        }

        private void Setup()
        {
            userBussiness.Setup((x) => x.CreateAsync(It.IsAny<Talent.Backend.Bussiness.Models.User>()));
            userBussiness.Setup((x) => x.DeleteAsync(It.IsAny<Talent.Backend.Bussiness.Models.User>())).Returns(Task.Delay(5));
        }
    }
}
