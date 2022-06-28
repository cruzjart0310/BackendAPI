using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Bussiness.Models
{
    public class UserForAuthentication
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ClientUri { get; set; }
    }
}
