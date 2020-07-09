using System;

namespace PPM.Api.Middleware
{
    public interface IExceptionHandler
    {
        ResponseDetails HandleException(Exception exception);
    }
}