using System;
using System.Threading.Tasks;
using Paragonr.Domain.Entities;

namespace Paragonr.Application.Interfaces
{
    public interface IUserAuthService
    {
        Task<User> AssertAuthorityToOperateOn(Guid requestUserRefKey, string password);

        Task<User> AuthenticateOrFail(string userQuery, string password);
    }
}
