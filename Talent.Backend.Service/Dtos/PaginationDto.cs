using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Service.Dtos
{
    public class PaginationDto
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationDto()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public PaginationDto(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}
