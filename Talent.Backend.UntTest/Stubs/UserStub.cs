using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.DataAccessEF.Entities;

namespace Talent.Backend.UnitTest.Stubs
{
    internal class UserStub
    {
        public static User user_1 = new User
        {
            Id = new Guid().ToString(),
            FirstName = "Tom",
            LastName =  "Raider",
            Email = "tomraider@test.com"
        };
    }
}
