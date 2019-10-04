namespace Paragonr.Application.Interfaces
{
    public interface IAuthTokenGenerator
    {
        string GenerateToken(in long userId, in string role);
    }
}
