//   DOMAIN IMPL

using Adapter.Database;
using DomainApi;
using DomainApi.Models;

namespace DomainImpl
{
    public class UserManager : IUserManager
    {

        private readonly UserDbContext _UserDbContext;

        public UserManager(UserDbContext userDbContext)
        {
            _UserDbContext = userDbContext ?? throw new ArgumentNullException(nameof(userDbContext));
        }
        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            _UserDbContext.Users.Add(user);
            _UserDbContext.SaveChanges();
        }

        public User GetUser(int userId)
        {
            return _UserDbContext.Users.Find(userId);
        }
        public List<User> GetAllUsers()
        {
            return _UserDbContext.Users.ToList();
        }

        public void UpdateUser(int userId, string userName, string email, string password)
        {
            var user = _UserDbContext.Users.Find(userId);
            if (user != null)
            {
                user.userName = userName;
                user.email = email;
                user.password = password;

                _UserDbContext.SaveChanges();
            }        
        }

        public void DeleteUser(int userId)
        {
            var user = _UserDbContext.Users.Find(userId);
            if (user != null)
            {
                _UserDbContext.Users.Remove(user);
                _UserDbContext.SaveChanges();
            }        
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

