using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Service.Dtos
{
    public class PaginationDto
    {
        public int Page { get; set; } = 1;
        public int RecordByPage = 10;
        private readonly int TotalMaximunRecordByPage = 50;

        public int RecordsByPage
        {
            get { return RecordByPage; }
            set { RecordByPage = (value > TotalMaximunRecordByPage ? TotalMaximunRecordByPage : value); }
        }
    }
}
