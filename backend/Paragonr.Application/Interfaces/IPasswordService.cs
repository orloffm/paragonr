using Paragonr.Domain.Entities;

namespace Paragonr.Application.Interfaces
{
    public interface IPasswordService
    {
        void SetPasswordForUser(string password, User user);

        bool IsPasswordSet(User u);

        bool CheckPassword(string password, User u);
    }
}
