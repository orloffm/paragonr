namespace Paragonr.Domain.Exceptions
{
    public sealed class PasswordNoProperProvidedException : DomainException
    {
        public PasswordNoProperProvidedException() : base("No proper password provided.")
        {
        }
    }
}
