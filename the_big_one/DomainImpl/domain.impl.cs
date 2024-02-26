//   DOMAIN IMPL
//   business logic and functionality of the proj.
//   contains the actual implementations of the interfaces or classes defined in the "DomainApi."


using Adapter.Database;
using DomainApi;

namespace DomainImpl
{
    public class UserManager : IUserManager
    {
        private readonly UserDatabase UserDatabase; 

        public UserManager(UserDatabase userDatabase)
        {
            UserDatabase = userDatabase;
        }

        public void AddUser(User user)
        {
            UserDatabase.AddUser(user);
        }

        public User GetUser(int userId)
        {
            return UserDatabase.GetUser(userId);
        }

        public List<User> GetAllUsers()
        {
            return UserDatabase.GetAllUsers();
        }
    }

    
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            throw new NotImplementedException();
        }

        public bool Verify(string passwordHash, string inputPassword)
        {
            throw new NotImplementedException();
        }
    }
}

