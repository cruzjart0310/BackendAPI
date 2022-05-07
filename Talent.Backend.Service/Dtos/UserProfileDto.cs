using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Service.Dtos
{
    public class UserProfileDto
    {
        public string Nickname { get; set; }
        public string EnglishLevel { get; set; }
        public string TechnicalKnowledg { get; set; }
        public string CvLink { get; set; }
        public string Avatar { get; set; }
    }
}
