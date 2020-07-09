using Microsoft.AspNetCore.Builder;

namespace PPM.Api.Middleware
{
    public static class Extensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(
          this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
