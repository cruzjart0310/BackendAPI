using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Talent.Backend.DataAccessEF.Entities
{
    public class User : IdentityUser
    {
        //public Guid Id { get; set; }    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool IsMarried { get; set; }
        public UserProfile UserProfile { get; set; }
        public IEnumerable<TeamUser> Teams { get; set; }
        public DateTime CreatedAt { get; set; }

        [NotMapped]
        public string Url { get; set; }
    }
}
