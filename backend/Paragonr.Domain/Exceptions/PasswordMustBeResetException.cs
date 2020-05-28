namespace Paragonr.Domain.Exceptions
{
    public sealed class PasswordMustBeResetException : DomainException
    {
        public PasswordMustBeResetException(string message) : base(message)
        {
        }
    }
}
