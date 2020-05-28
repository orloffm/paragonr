using System;
using MediatR;

namespace Paragonr.Application.Users.Commands.ChangePassword
{
    public sealed class ChangePasswordCommand : IRequest<ChangePasswordResult>
    {
        public string NewPassword { get; set; }

        public string OldPassword { get; set; }

        public Guid UserRefKey { get; set; }
    }
}
