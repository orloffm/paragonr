using System;

namespace Paragonr.Application.Common.Exceptions
{
    public sealed class UserNotFoundException : AppException
    {
        public UserNotFoundException(Guid userRefKey) : base($"User with ref key {userRefKey} not found.")
        {
        }

        public UserNotFoundException(string userQuery) : base($"No user identified by string \"{userQuery}\" was found.")
        {
        }
    }
}
