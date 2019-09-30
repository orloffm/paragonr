using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Paragonr.Application.Common.Exceptions;
using Paragonr.Application.Interfaces;

namespace Paragonr.WebApi.Services
{
    public sealed class WebApiCurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WebApiCurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public long GetCurrentUserId()
        {
            string userIdString = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrWhiteSpace(userIdString))
            {
                throw new NoUserAuthenticatedException();
            }

            return long.Parse(userIdString);
        }
    }
}
