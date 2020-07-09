using PPM.Domain.Exceptions;
using System;
using System.Net;

namespace PPM.Api.Middleware.Exceptions
{
    public class ExceptionHandler : IExceptionHandler
    {
        public ResponseDetails HandleException(Exception exception)
        {
            if (exception is PPMException)
            {
                var ss = exception as PPMException;
                return new ResponseDetails()
                {
                    ErrorCode = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = ss.Message,
                    StatusCode = (int)ss.ExceptionCode,
                };
            }
            return new ResponseDetails()
            {
                ErrorCode = (int)HttpStatusCode.InternalServerError,
                ErrorMessage = exception.Message,
                StatusCode = (int)HttpStatusCode.InternalServerError,
            };
        }
    }
}
