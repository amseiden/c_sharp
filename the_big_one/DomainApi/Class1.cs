using Adapter.Database;

namespace DomainApi
{
    public interface IUserManager
    {
        void AddUser(User user);
        User GetUser(int userId);
        List<User> GetAllUsers();
    }
    
}

