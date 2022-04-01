using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talent.Backend.Bussiness.Models;

namespace Talent.Backend.Bussiness.Mappers
{
    public static class PaginationMapper
    {
        public static Talent.Backend.DataAccessEF.Models.Pagination Map(Pagination pagination) => new DataAccessEF.Models.Pagination()
        {
            Page = pagination.Page,
            RecordByPage = pagination.RecordByPage,
            TotalMaximunRecordByPage = pagination.TotalMaximunRecordByPage    
        };
    }
}
