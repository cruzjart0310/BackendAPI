using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Talent.Backend.API.Extensions
{
    public static class HttpContextExtensions
    {
        public static void ParameterPagination<T>(this Microsoft.AspNetCore.Http.HttpContext httpContex, IQueryable<T> queryable)
        {
            if (httpContex == null)
            {
                throw new ArgumentNullException(nameof(httpContex));
            }

            double total = queryable.Count();
            httpContex.Response.Headers.Add("totalRegister", total.ToString());
        }
    }
}
