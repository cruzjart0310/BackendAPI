﻿namespace Talent.Backend.DataAccessEF.Models
{
    public class ResetPassword
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
