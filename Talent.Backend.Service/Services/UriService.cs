using Microsoft.AspNetCore.WebUtilities;
using System;
using Talent.Backend.Service.Contracts;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }
        public Uri GetUri(PaginationDto paginationDto, string route)
        {
            var endPoint = new Uri($"{_baseUri}{route}");
            var modifiedUri = QueryHelpers
                .AddQueryString(endPoint.ToString(), "page", paginationDto.PageNumber.ToString());
            modifiedUri = QueryHelpers
                .AddQueryString(modifiedUri, "pageSize", paginationDto.PageSize.ToString());
            return new Uri(modifiedUri);
        }
    }
}
