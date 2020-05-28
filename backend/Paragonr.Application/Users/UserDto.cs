using Paragonr.Domain.Entities;
using Paragonr.Tools.Mapping;
using Paragonr.Tools.Mapping.Dto;

namespace Paragonr.Application.Users
{
    public sealed class UserDto : EntityBaseDto, IMapFrom<User>
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }
    }
}
