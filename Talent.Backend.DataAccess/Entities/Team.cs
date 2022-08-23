using System;
using System.Collections.Generic;

namespace Talent.Backend.DataAccessEF.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[NotMapped]

        //Todo:verify if this work
        public IEnumerable<TeamUser> Users { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
