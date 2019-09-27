using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Paragonr.Application.Auth.Commands.Login
{
   public sealed  class LoginCommand : IRequest<LoginResponse>
    {
        public string User { get; set; }

        public string Password { get; set; }
    }
}
