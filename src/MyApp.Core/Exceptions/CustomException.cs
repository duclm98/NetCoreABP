using Newtonsoft.Json.Linq;
using System;

namespace MyApp.Exceptions
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public object Result { get; set; }
        public string ContentType { get; set; } = @"text/plain";

        public CustomException(string message, int statusCode, object result = null!)
            : base(message)
        {
            StatusCode = statusCode;
            Result = result;
        }

        public CustomException(int statusCode, Exception inner)
            : this(inner.ToString(), statusCode) { }

        public CustomException(int statusCode, JObject errorObject)
            : this(errorObject.ToString(), statusCode)
        {
            ContentType = @"application/json";
        }
    }
}
