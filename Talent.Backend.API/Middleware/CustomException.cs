using System;
using System.Globalization;

namespace Talent.Backend.API.Middleware
{
    public class CustomException : Exception
    {

        public CustomException() : base()
        {
        }

        public CustomException(string message) : base(message)
        {
        }

        public CustomException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }

    }
}
