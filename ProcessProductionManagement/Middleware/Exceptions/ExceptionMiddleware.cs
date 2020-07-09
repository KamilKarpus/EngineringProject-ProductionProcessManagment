using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace PPM.Api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private IExceptionHandler _handler;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, IExceptionHandler handler)
        {
            _handler = handler;
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        public async Task HandleException(HttpContext context, Exception exception)
        {
            var response = _handler.HandleException(exception);
            context.Response.StatusCode = (int)response.ErrorCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new
            {
                errorCode = response.StatusCode,
                message = response.ErrorMessage,
            }));
        }
    }
}
