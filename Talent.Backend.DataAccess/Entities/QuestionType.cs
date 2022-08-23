using System;

namespace Talent.Backend.DataAccessEF.Entities
{
    public class QuestionType
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
