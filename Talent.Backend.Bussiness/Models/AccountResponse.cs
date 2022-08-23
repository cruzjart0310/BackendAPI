using System.Collections.Generic;

namespace Talent.Backend.Bussiness.Models
{
    public class AccountResponse<T>
    {
        public T Element { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
