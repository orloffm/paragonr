namespace Paragonr.Domain.Exceptions
{
    public sealed class MustBeAdminException : DomainException
    {
        public MustBeAdminException() : base("Must be admin to proceed with this workflow.")
        {
        }
    }
}
