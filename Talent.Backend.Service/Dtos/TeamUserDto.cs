using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Service.Dtos
{
    public class TeamUserDto
    {
        [NotMapped]
        //public UserAssignedDto User { get; set; }
        public UserResponsibleDto UserResponsible { get; set; }
        public TeamDto TeamAssigned { get; set; }
        public Byte Current { get; set; }
        public DateTime DateInit { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
