using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Paragonr.Application.Common;
using Paragonr.Domain.Exceptions;

namespace Paragonr.WebApi.Common.Middleware
{
    public sealed class DomainExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public DomainExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, DomainException exception)
        {
            HttpStatusCode code;
            switch (exception)
            {
                case NoUserAuthenticatedException _:
                    code = HttpStatusCode.Unauthorized;
                    break;

                case PasswordIncorrectException _:
                case MustBeAdminException _:
                case PasswordNoProperProvidedException _:
                case UserNotFoundException _:
                default:
                    code = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            var result = JsonSerializer.Serialize(
                new ErrorResult
                {
                    Message = exception.Message
                }
            );

            return context.Response.WriteAsync(result);
        }
    }
}
