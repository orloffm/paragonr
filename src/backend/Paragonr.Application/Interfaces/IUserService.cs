using System.Collections.Generic;
using Paragonr.Entities;

namespace Paragonr.Application.Interfaces
{
    public interface IUserService
    {
        User Authenticate(string username, string password);

        User Create(User user, string password);

        void Delete(int id);

        IEnumerable<User> GetAll();

        User GetById(int id);

        void Update(User user, string password = null);
    }
}