using Microsoft.AspNetCore.Builder;

namespace Paragonr.WebApi.Common.Middleware
{
    public static class DomainExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseDomainExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DomainExceptionHandlerMiddleware>();
        }
    }
}
