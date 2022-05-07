using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Contracts;
using Talent.Backend.Service;
using Talent.Backend.Service.Contracts;
using Talent.Backend.UnitTest.Mocks.User;
using Talent.Backend.UnitTest.Stubs;

namespace Talent.Backend.UnitTest
{
    public class Tests
    {
        private static IUserService _userService;

        [SetUp]
        public void Setup()
        {
            Mock<IUserBussiness> userBussiness = new UserBussinessMock().userBussiness;

           // _userService = new UserService(userBussiness.Object);
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public async Task Get_All_Users()
        {
            //Arrange
            var user = UserStub.user_1;
            //var result = await _userService.GetAllUserAsync();
            //Assert.IsNull(result);
        }
    }
}