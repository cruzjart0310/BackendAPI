using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Bussiness.Models
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
            Id = Guid.NewGuid().ToString();
        }
    }
}
