using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Bussiness.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[NotMapped]
        public ICollection<TeamUser> Users { get; set; }
    }
}
