using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Bussiness.Models
{
    public class Pagination
    {
        public int Page { get; set; }
        public int RecordByPage { get; set; }
        public int TotalMaximunRecordByPage { get; set; }
    }
}
