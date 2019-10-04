using Paragonr.Application.Common;
using Paragonr.Application.Interfaces;

namespace Paragonr.Application.Services
{
    public sealed class RoleService : IRoleService
    {
        public string GetRoleByAdminStatus(in bool userIsAdmin)
        {
            return userIsAdmin ? Roles.Admin : Roles.User;
        }
    }
}
