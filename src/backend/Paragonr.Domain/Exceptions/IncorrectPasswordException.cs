namespace Paragonr.Domain.Exceptions
{
    public sealed class IncorrectPasswordException : AppException
    {
        public IncorrectPasswordException() : base("Password is incorrect.")
        {
        }
    }
}
