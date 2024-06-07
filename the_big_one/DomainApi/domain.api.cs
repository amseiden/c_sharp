// DOMAIN API

using DomainApi.Models;

namespace DomainApi
{
    public interface IUserManager
    {
        void AddUser(User user);
        User GetUser(int userId);
        List<User> GetAllUsers();
        void UpdateUser(int userId, string userUsername, string userEmail, string userPassword, string firstName, string lastName);
        void DeleteUser(int userId);
        //  void UpdateUser(int userId, string userUsername, string userEmail, string userPassword);
        Task<User> VerifyCredentialsAsync(string username, string password); 

    }

    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string passwordHash, string inputPassword);
    }
}
