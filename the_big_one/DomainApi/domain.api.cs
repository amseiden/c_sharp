//   DOMAIN API

using DomainApi.Models;

namespace DomainApi
{
    public interface IUserManager
    {
        void AddUser(User user);
        User GetUser(int userId);
        List<User> GetAllUsers();
        void UpdateUser(int userId, string userName, string email, string password);
        void DeleteUser(int userId);
    }

    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string passwordHash, string inputPassword);
    }
}