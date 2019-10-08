namespace Paragonr.Application.Auth.Commands.Login
{
    public sealed class LoginCommandResult
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Token { get; set; }
    }
}
