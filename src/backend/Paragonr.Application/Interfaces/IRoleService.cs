namespace Paragonr.Application.Interfaces
{
    public interface IRoleService
    {
        string GetRoleByAdminStatus(in bool userIsAdmin);
    }
}
