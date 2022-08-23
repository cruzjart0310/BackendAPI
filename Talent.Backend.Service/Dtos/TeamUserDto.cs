using System;
using System.ComponentModel.DataAnnotations.Schema;

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
