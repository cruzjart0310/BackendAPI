using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Service.Dtos
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Point { get; set; }
        public QuestionDto Question { get; set; }
    }
}
