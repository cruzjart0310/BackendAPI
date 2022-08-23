using System;
using System.Linq;
using Talent.Backend.Service.Contracts;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.API.Helpers
{
    public static class PaginationHelper
    {
        public static PagedResponseDto<IQueryable<T>> CreateResponse<T>(IQueryable<T> queriable, PaginationDto paginationDto, int totalRecords, IUriService uriService, string route)
        {
            var response = new PagedResponseDto<IQueryable<T>>(queriable, paginationDto.PageNumber, paginationDto.PageSize);
            var totalPages = ((double)totalRecords / (double)paginationDto.PageSize);
            var roundedTotalPage = Convert.ToInt32(Math.Ceiling(totalPages));

            response.PreviousPage =
                paginationDto.PageNumber - 1 >= 1 && paginationDto.PageNumber <= roundedTotalPage
                ? uriService.GetUri(new PaginationDto(paginationDto.PageNumber - 1, paginationDto.PageSize), route)
                : null;

            response.NextPage =
               paginationDto.PageNumber >= 1 && paginationDto.PageNumber < roundedTotalPage
               ? uriService.GetUri(new PaginationDto(paginationDto.PageNumber + 1, paginationDto.PageSize), route)
               : null;

            response.FirstPage = uriService.GetUri(new PaginationDto(1, paginationDto.PageSize), route);
            response.LastPage = uriService.GetUri(new PaginationDto(roundedTotalPage, paginationDto.PageSize), route);
            response.TotalPages = roundedTotalPage;
            response.TotalRecords = totalRecords;

            return response;
        }
    }
}
