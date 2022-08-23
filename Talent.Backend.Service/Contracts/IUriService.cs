using System;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Contracts
{
    public interface IUriService
    {
        public Uri GetUri(PaginationDto paginationDto, string route);
    }
}
