using System;
using System.Collections.Generic;

namespace Talent.Backend.Bussiness.Models
{
    public class Question
    {
        public int? Id { get; set; }
        public string Title { get; set; }

        public int TypeId { get; set; }
        public QuestionType? Type { get; set; }

        public int SurveyId { get; set; }
        public Survey? Survey { get; set; }
        public IEnumerable<Answer>? Answers { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
