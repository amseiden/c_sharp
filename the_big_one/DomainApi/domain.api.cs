//   DOMAIN API
//   contains project's interfaces or API used by other parts of application.
//   defines interfaces or abstract classes that are implemented in the "DomainImpl".


using Adapter.Database;

namespace DomainApi
{
    public interface IUserManager
    {
        void AddUser(Adapter.Database.User user);
        Adapter.Database.User GetUser(int userId);
        List<Adapter.Database.User> GetAllUsers();
    }

    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string passwordHash, string inputPassword);
    }
}


