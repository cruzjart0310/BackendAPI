using System;

namespace Talent.Backend.DataAccessEF.Models
{
    public class OrderByClass<T>
    {
        public OrderByClass()
        {

        }

        public OrderByClass(Func<T, object> orderBy, bool isAscending)
        {
            OrderBy = orderBy;
            IsAscending = isAscending;
        }


        public Func<T, object> OrderBy { get; set; }
        public bool IsAscending { get; set; }
    }
}
