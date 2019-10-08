using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Paragonr.Application.Interfaces;
using Paragonr.Domain.Entities;

namespace Paragonr.Application.Auth.Commands.Login
{
    public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResult>
    {
        private readonly IAuthTokenGenerator _authTokenGenerator;
        private readonly IRoleService _roleService;
        private readonly IUserAuthService _userAuthService;

        public LoginCommandHandler(IAuthTokenGenerator authTokenGenerator, IRoleService roleService, IUserAuthService userAuthService)
        {
            _authTokenGenerator = authTokenGenerator;
            _roleService = roleService;
            _userAuthService = userAuthService;
        }

        public async Task<LoginCommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User user = await _userAuthService.AuthenticateOrFail(request.UserQuery, request.Password);

            var role = _roleService.GetRoleByAdminStatus(user.IsAdmin);
            var token = _authTokenGenerator.GenerateToken(user.Id, role);

            return new LoginCommandResult
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = token
            };
        }
    }
}
