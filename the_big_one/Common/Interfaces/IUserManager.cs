using WebApp.Models;

namespace Common.Interfaces
{
    public interface IUserManager
    {
        void AddUser(User user);
        User GetUser(int userId);
        List<User> GetAllUsers();
        void UpdateUser(int userId, string? username, string? email, string? password, string? firstName, string? lastName);
        void DeleteUser(int userId);
        Task<User> VerifyCredentialsAsync(string username, string password);
    }
}