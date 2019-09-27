using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Paragonr.Application.Auth.Commands.Login
{
   public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
    {
        public Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
