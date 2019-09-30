namespace Paragonr.Application.Common.Exceptions
{
    public sealed class IncorrectPasswordException : AppException
    {
        public IncorrectPasswordException() : base("Password is incorrect.")
        {
        }
    }
}
