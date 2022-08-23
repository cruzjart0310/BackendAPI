using Talent.Backend.Bussiness.Models;

namespace Talent.Backend.Bussiness.Mappers
{
    public static class PaginationMapper
    {
        public static Talent.Backend.DataAccessEF.Models.Pagination Map(Pagination pagination) => new DataAccessEF.Models.Pagination()
        {
            Page = pagination.Page,
            PageZise = pagination.PageZise,
        };
    }
}
