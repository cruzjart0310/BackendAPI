using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.DataAccessEF.Entities;

namespace Talent.Backend.DataAccessEF.Entities
{
    public class User: IdentityUser
    {
        //public Guid Id { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool IsMarried { get; set; }
        public UserProfile UserProfile { get; set; }
        public IEnumerable<TeamUser> Teams { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
    }
}
