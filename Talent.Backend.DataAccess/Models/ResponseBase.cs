using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talent.Backend.DataAccessEF.Models
{
    //public class HttpSatusCodeApi
    //{
    //    public readonly int InternalServerError = (int)System.Net.HttpStatusCode.InternalServerError;
    //    public readonly int Ok = (int)System.Net.HttpStatusCode.OK;
    //    public readonly int NotFound = (int)System.Net.HttpStatusCode.NotFound;
    //    public readonly int Created = (int)System.Net.HttpStatusCode.Created;
    //    public readonly int NoContent = (int)System.Net.HttpStatusCode.NoContent;
    //}

    public class ResponseBase<T>
    {
        public int CodeResult { get; set; }

        public int CodeDataBase { get; set; }

        public bool Success { get; set; }

        public IEnumerable<T> List { get; set; }

        public T Element { get; set; }

        public Error Error { get; set; }


        public ResponseBase()
        {
            Success = true;
            CodeDataBase = 0;
            CodeResult = 200;
        }

    }

    public class Error
    {
        public string Message { get; set; }
        public Exception Exception { get; set; }

        public Error(string message, Exception? exception)
        {
            Message = message;
            Exception = exception;
        }
    }
}
