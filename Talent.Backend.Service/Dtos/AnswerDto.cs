using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Service.Dtos
{
    public class AnswerDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public byte IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public QuestionDto? Question { get; set; }
        public DateTime CreatedAt { get; set; } 
    }
}
