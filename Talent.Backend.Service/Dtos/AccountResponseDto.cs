using System.Collections.Generic;

namespace Talent.Backend.Service.Dtos
{
    public class AccountResponseDto<T>
    {
        public T Element { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
