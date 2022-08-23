using System;

namespace Talent.Backend.Bussiness.Models
{
    public class Answer
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public byte IsCorrect { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
