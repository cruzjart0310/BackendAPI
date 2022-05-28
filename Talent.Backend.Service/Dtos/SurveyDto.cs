using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Service.Dtos
{
  
    public class SurveyDto
    {
        public int? Id { get; set; }

        [Required]
        public string? Name { get; set; }
        public IEnumerable<QuestionDto> Questions { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
