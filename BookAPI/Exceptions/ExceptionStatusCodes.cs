using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BookAPI.Exceptions
{
    public static class ExceptionStatusCodes
    {
        private static Dictionary<Type, HttpStatusCode> exceptionStatusCode = new Dictionary<Type, HttpStatusCode>
        {
            {typeof(BookNotFoundException), HttpStatusCode.NotFound},
            {typeof(IDZeroException), HttpStatusCode.BadRequest}
        };

        public static HttpStatusCode GetExceptionStatusCode(Exception exception)
        {
            bool exceptionFound = exceptionStatusCode.TryGetValue(exception.GetType(), out var statusCode);
            return exceptionFound ? statusCode : HttpStatusCode.InternalServerError;
        }
    }
}
