using System.Collections.Generic;
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
}

