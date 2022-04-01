using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.DataAccessEF.Models;

namespace Talent.Backend.DataAccessEF.Extensions
{
    internal static class IQueriableExtensions
    {
        public static IQueryable<T> Pagination<T>(this IQueryable<T> queryable, Pagination pagination)
        {
            return queryable
                .Skip((pagination.Page - 1) * pagination.RecordByPage)
                .Take(pagination.RecordByPage);
        }
    }
}
