namespace Paragonr.Domain.Exceptions
{
    public sealed class NoUserAuthenticatedException : DomainException
    {
        public NoUserAuthenticatedException() : base("No user is authenticated.")
        {
        }
    }
}
