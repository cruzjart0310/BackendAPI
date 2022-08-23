using System;

namespace Talent.Backend.Bussiness.Models
{
    public class TeamUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        //[NotMapped]
        public User User { get; set; }
        public string UserResponsibleId { get; set; }
        //[NotMapped]
        public User UserResponsible { get; set; }
        public int TeamAssignedId { get; set; }
        //[NotMapped]
        public Team TeamAssigned { get; set; }
        public Byte Current { get; set; }
        public DateTime DateInit { get; set; }
        public DateTime DateEnd { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
