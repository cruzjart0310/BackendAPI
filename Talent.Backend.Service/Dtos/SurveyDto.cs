using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Service.Dtos
{
  
    public class SurveyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<QuestionDto> Questions { get; set; }
        public DateTime CreatedAt { get; set; }

        //public DateTime UpdatedAt { get; set; }
        //public DateTime DeletedAt { get; set; }
    }
}
