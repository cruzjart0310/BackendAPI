using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Service.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public QuestionTypeDto Type { get; set; }
        //public SurveyDto Survey { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; }
        public DateTime CreatedAt { get; set; }
        //public DateTime UpdatedAt { get; set; }
        //public DateTime DeletedAt { get; set; }
    }
}
