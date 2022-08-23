﻿using System.Collections.Generic;

namespace Talent.Backend.Bussiness.Models
{
    public class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public bool IsMarried { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public UserProfile UserProfile { get; set; }

        public IEnumerable<TeamUser> Teams { get; set; }
    }
}
