using MediatR;

namespace Paragonr.Application.Auth.Commands.Login
{
    public sealed class LoginCommand : IRequest<LoginResult>
    {
        public string Password { get; set; }

        public string UserQuery { get; set; }
    }
}
