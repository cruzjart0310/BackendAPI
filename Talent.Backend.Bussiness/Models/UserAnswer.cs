using System;
using System.Collections.Generic;

namespace Talent.Backend.Bussiness.Models
{
    public class UserAnswer
    {
        public int Id { get; set; }
        public IEnumerable<int> UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<int> AnswerId { get; set; }
        public IEnumerable<Answer> Answer { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
