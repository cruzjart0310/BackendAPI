using System;
using System.Collections.Generic;

namespace Talent.Backend.Service.Dtos
{
    public class LoginResposeDto<T>
    {
        public T Element { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public ICollection<string> Errors { get; set; }
    }
}
