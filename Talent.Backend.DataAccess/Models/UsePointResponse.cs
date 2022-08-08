using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.DataAccessEF.Models
{
    public class UserPointResponse<T>
    {
        public double Points { get; set; }
        public T Element { get; set; }
    }
}
