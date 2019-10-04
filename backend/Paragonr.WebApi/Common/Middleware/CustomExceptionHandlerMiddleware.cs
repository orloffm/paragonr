using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Paragonr.Domain.Exceptions;

namespace Paragonr.WebApi.Common.Middleware
{
    public sealed class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (AppException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, AppException exception)
        {
            HttpStatusCode code ;
            switch (exception)
            {
                case IncorrectPasswordException _:
                case MustBeAdminException _:
                case NoProperPasswordProvidedException _:
                case NoUserAuthenticatedException _:
                case UserNotFoundException _:
                    code = HttpStatusCode.Unauthorized;
                    break;
                
                default:
                    code = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode =(int) code;

             var   result = JsonSerializer.Serialize(new { error = exception.Message });

            return context.Response.WriteAsync(result);
        }
    }
}
