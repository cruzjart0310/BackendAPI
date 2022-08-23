using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Talent.Backend.DataAccessEF.Entities
{
    public class Survey
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }
        public IEnumerable<Question> Questions { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
