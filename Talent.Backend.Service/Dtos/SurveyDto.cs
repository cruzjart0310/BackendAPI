using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Talent.Backend.Service.Dtos
{

    public class SurveyDto
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
        public IEnumerable<QuestionDto> Questions { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
