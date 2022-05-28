using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Service.Dtos
{
    public class ResponseDto<T>
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public int Status { get; set; }
        public string TraceId { get; set; }
        public T Data { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string ErrorDetails { get; set; }

        public ResponseDto()
        {
        }
        public ResponseDto(T data)
        {
            Status = 200;
            Success = true;
            Message = string.Empty;
            Data = data;
        }

        public static ResponseDto<T> Fail(string errorMessage, string errorDetails)
        {
            return new ResponseDto<T> { Success = false, Message = errorMessage, ErrorDetails= errorDetails };
        }
        
    }
}
