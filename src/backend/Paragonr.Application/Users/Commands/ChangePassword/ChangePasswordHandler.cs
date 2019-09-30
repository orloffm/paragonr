using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Paragonr.Application.Common.Exceptions;
using Paragonr.Application.Interfaces;
using Paragonr.Domain;
using Paragonr.Domain.Entities;

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
                throw new NoProperPasswordProvidedException();
            }

            User user = await _userAuthService.AssertAuthority(request.UserRefKey, request.OldPassword);

            _passService.CreatePasswordHash(request.NewPassword, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.SaveChangesAsync(cancellationToken);

            return new ChangePasswordResult();
        }
    }
}
