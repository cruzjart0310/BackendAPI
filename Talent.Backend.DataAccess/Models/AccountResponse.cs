using System.Collections.Generic;

namespace Talent.Backend.DataAccessEF.Models
{
    public class AccountResponse<T>
    {
        public T Element { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
