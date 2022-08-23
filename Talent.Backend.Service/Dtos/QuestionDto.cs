using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Talent.Backend.Service.Dtos
{
    public class QuestionDto
    {
        public int? Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int TypeId { get; set; }
        public QuestionTypeDto? Type { get; set; }

        [Required]
        public int SurveyId { get; set; }
        public SurveyDto? Survey { get; set; }
        public IEnumerable<AnswerDto>? Answers { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
