using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Service.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public string[] Errors { get; set; }
        public string Message { get; set; }
        public string ErroDetails { get; set; }

        public ResponseDto()
        {
        }
        public ResponseDto(T data)
        {
            Succeeded = true;
            Message = string.Empty;
            Errors = null;
            Data = data;
        }

        public static ResponseDto<T> Fail(string errorMessage, string errorDetails)
        {
            return new ResponseDto<T> { Succeeded = false, Message = errorMessage, ErroDetails= errorDetails };
        }
        
    }
}
