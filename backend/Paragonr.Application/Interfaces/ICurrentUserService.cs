using System;

namespace Paragonr.Application.Interfaces
{
    public interface ICurrentUserService
    {
        /// <summary>
        /// Returns the id of the currently logged in user.
        /// </summary>
        long GetCurrentUserId();
    }
}
