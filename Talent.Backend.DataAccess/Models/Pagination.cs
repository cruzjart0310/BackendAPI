using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.DataAccessEF.Models
{
    public class Pagination
    {
        public int Page { get; set; }
        public int RecordByPage { get; set; }
        public int TotalMaximunRecordByPage { get; set; }

        //public Expression<Func<T, bool>> Where { get; set; }
        //public Func<T, object> OrderBy { get; set; }
        //public Func<T, object> OrderByDescending { get; set; }
    }
}
