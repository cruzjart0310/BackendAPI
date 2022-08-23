using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Talent.Backend.DataAccessEF.Entities
{
    public class UserProfile
    {
        public string Id { get; set; }
        public string Nickname { get; set; }
        public string EnglishLevel { get; set; }
        public string TechnicalKnowledg { get; set; }
        public string CvLink { get; set; }
        public string Avatar { get; set; }

        [ForeignKey("UserId")]
        public string UserId { get; set; }

        public UserProfile()
        {
            Id = Guid.NewGuid().ToString().ToLower();
        }
    }
}
