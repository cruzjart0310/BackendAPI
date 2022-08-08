using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Service.Dtos
{
    public class UserPointResponseDto<T>
    {
        public T Element { get; set; }
        public double Points { get; set; }
    }
}
