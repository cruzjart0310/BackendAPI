using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.DataAccessEF.Entities
{
    public class Answer
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public byte IsCorrect { get; set; }

        [ForeignKey("QuestionFK")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
