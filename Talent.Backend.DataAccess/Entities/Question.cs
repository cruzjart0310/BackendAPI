using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.DataAccessEF.Entities
{
    public class Question
    {
        public int? Id { get; set; }
        public string Title { get; set; }

        [ForeignKey("TypeFK")]
        public int TypeId { get; set; }
        public QuestionType? Type { get; set; }

        [ForeignKey("SurveyFK")]
        public int SurveyId { get; set; }
        public Survey? Survey { get; set; }
        public IEnumerable<Answer> Answers { get; set; }
        public DateTime CreatedAt { get; set; } 
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
