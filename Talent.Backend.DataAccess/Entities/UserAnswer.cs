using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.DataAccessEF.Entities
{
    public class UserAnswer
    {
        public int Id { get; set; } 
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("AnswerId")]
        public int AnswerId { get; set; }
        public IEnumerable<Answer> Answer { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
