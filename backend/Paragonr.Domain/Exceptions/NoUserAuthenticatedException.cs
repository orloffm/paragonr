﻿namespace Paragonr.Domain.Exceptions
{
    public sealed class NoUserAuthenticatedException : AppException
    {
        public NoUserAuthenticatedException() : base("No user is authenticated.")
        {
        }
    }
}