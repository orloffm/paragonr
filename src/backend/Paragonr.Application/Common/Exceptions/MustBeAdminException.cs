namespace Paragonr.Application.Common.Exceptions
{
    public sealed class MustBeAdminException : AppException
    {
        public MustBeAdminException() : base("Must be admin to proceed with this workflow.")
        {
        }
    }
}
