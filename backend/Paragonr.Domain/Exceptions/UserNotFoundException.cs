﻿using System;

namespace Paragonr.Domain.Exceptions
{
    public sealed class UserNotFoundException : DomainException
    {
        public UserNotFoundException(Guid userRefKey) : base($"User with ref key {userRefKey} not found.")
        {
        }

        public UserNotFoundException(string userQuery) : base($"No user identified by string \"{userQuery}\" was found.")
        {
        }
    }
}
