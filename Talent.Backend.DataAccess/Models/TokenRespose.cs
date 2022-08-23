using System;
using System.Collections.Generic;

namespace Talent.Backend.DataAccessEF.Models
{
    public class TokenRespose<T>
    {
        public T Element { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public ICollection<string> Errors { get; set; }
    }
}
