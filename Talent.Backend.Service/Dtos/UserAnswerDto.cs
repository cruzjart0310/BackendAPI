using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Talent.Backend.Service.Dtos
{

    public class UserAnswerDto
    {
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public UserAnswerAssignDto User { get; set; }
        public IEnumerable<AnswerAssingDto> Answer { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
