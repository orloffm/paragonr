using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Paragonr.Application.Interfaces;
using Paragonr.Domain;
using Paragonr.Domain.Entities;
using Paragonr.Domain.Exceptions;

namespace Paragonr.Application.Users.Commands.ChangePassword
{
    public sealed class ChangePasswordHandler : IRequestHandler<ChangePasswordCommand, ChangePasswordResult>
    {
        private readonly IBudgetDbContext _context;
        private readonly IPasswordService _passService;
        private readonly IUserAuthService _userAuthService;

        public ChangePasswordHandler(IBudgetDbContext context, IUserAuthService userAuthService, IPasswordService passService)
        {
            _context = context;
            _userAuthService = userAuthService;
            _passService = passService;
        }

        public async Task<ChangePasswordResult> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.NewPassword))
            {
                throw new PasswordNoProperProvidedException();
            }

            User user = await _userAuthService.AssertAuthorityToOperateOn(request.UserRefKey, request.OldPassword);

            _passService.SetPasswordForUser(request.NewPassword, user);
            await _context.SaveChangesAsync(cancellationToken);

            return new ChangePasswordResult();
        }
    }
}
