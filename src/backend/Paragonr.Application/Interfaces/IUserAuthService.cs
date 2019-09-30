using System;
using System.Threading.Tasks;
using Paragonr.Domain.Entities;

namespace Paragonr.Application.Interfaces
{
    public interface IUserAuthService
    {
        Task<User> AssertAuthority(Guid requestUserRefKey, string requestOldPassword);

        Task<User> AuthenticateOrFail(string userQuery, string password);
    }
}
