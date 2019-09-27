using System;
using System.Collections.Generic;
using System.Text;
using Paragonr.Application.Infrastructure;
using Paragonr.Domain.Entities;

namespace Paragonr.Application.Dtos
{
    public sealed class UserDto : EntityBaseDto, IMapFrom<User>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
    }
}
