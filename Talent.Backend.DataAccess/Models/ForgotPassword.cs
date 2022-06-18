using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.DataAccessEF.Models
{
    public class ForgotPassword
    {
        public string Email { get; set; }

        public string ClientUri { get; set; }
    }
}
