using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Bussiness.Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Point { get; set; }
        public Question Question { get; set; }
    }
}
