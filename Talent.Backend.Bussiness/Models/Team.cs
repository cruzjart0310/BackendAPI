using System.Collections.Generic;

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
