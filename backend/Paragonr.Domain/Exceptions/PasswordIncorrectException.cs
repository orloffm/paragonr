namespace Paragonr.Domain.Exceptions
{
    public sealed class PasswordIncorrectException : DomainException
    {
        public PasswordIncorrectException() : base("Password is incorrect.")
        {
        }
    }
}
