using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Service.Dtos;

namespace Talent.Backend.Service.Mappers
{
    public static class PaginationMapper
    {
        public static Talent.Backend.Bussiness.Models.Pagination Map(PaginationDto paginationDto)
            => new Bussiness.Models.Pagination
            {
                Page = paginationDto.Page,  
                RecordByPage = paginationDto.RecordByPage,
                TotalMaximunRecordByPage = paginationDto.RecordsByPage
            };
        
    }
}
