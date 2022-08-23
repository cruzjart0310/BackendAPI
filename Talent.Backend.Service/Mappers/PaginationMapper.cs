using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Mappers
{
    public static class PaginationMapper
    {
        public static Talent.Backend.Bussiness.Models.Pagination Map(PaginationDto paginationDto)
            => new Bussiness.Models.Pagination
            {
                Page = paginationDto.PageNumber,
                PageZise = paginationDto.PageSize,
            };

    }
}
