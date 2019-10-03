﻿namespace Paragonr.Domain.Exceptions
{
    public sealed class NoProperPasswordProvidedException : AppException
    {
        public NoProperPasswordProvidedException() : base("No proper password provided.")
        {
        }
    }
}