using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.Common.Models
{
    public class ResponseBaseApi<T>
    {
        public int CodeResult { get; set; }

        public int CodeDataBase { get; set; }

        public int Success { get; set; }

        public IEnumerable<T> List { get; set; }

        public T Element { get; set; }

        public Error Error { get; set; }    

        
    }

    public class Error
    {
        public string Message { get; set; }
        public int? Code { get; set; }
        public Exception Exception { get; set; }

        public Error(string message, int? codeError, Exception? exception)
        {
            Message = message;
            Code = codeError;
            Exception = exception;
        }
    }
}
