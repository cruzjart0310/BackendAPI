﻿using System.Linq;
using Talent.Backend.DataAccessEF.Models;

namespace Talent.Backend.DataAccessEF.Extensions
{
    internal static class IQueriableExtensions
    {
        public static IQueryable<T> Pagination<T>(this IQueryable<T> queryable, Pagination pagination)
        {
            var q = queryable

                .Skip((pagination.Page - 1) * pagination.Page)
                .Take(pagination.PageZise);

            return q;
        }

        public static IOrderedQueryable<TSource> Sort<TSource>(this IQueryable<TSource> source, bool ascending, string sortingProperty)
        {
            if (ascending)
                return source.OrderBy(item => item.GetReflectedPropertyValue(sortingProperty));
            else
                return source.OrderByDescending(item => item.GetReflectedPropertyValue(sortingProperty));
        }

        private static object GetReflectedPropertyValue(this object subject, string field)
        {
            return subject.GetType().GetProperty(field).GetValue(subject, null);
        }
    }
}
