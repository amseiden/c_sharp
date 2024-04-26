//   DOMAIN IMPL

using Adapter.Database;
using DomainApi;
using DomainApi.Models;

namespace DomainImpl
{
    public class UserManager : IUserManager
    {
        private readonly UserDbContext _userDbContext;
        private readonly IPasswordHasher _passwordHasher;

        public UserManager(UserDbContext userDbContext, IPasswordHasher passwordHasher)
        {
            _userDbContext = userDbContext ?? throw new ArgumentNullException(nameof(userDbContext));
            _passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }
        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _userDbContext.Users.Add(user);
            _userDbContext.SaveChanges();
        }

        public User GetUser(int userName)
        {
            return _userDbContext.Users.Find(userName);
        }
        public List<User> GetAllUsers()
        {
            return _userDbContext.Users.ToList();
        }

        public void UpdateUser(int userId, string username, string email, string password, string firstName, string lastName)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(int userId, string? userName, string? email, string? password)
        {
            var user = _userDbContext.Users.Find(userId);
            if (user != null)
            {
                user.Username = userName;
                user.Email = email;
                user.Password = password;

                _userDbContext.SaveChanges();
            }        
        }

        public void DeleteUser(int userId)
        {
            var user = _userDbContext.Users.Find(userId);
            if (user != null)
            {
                _userDbContext.Users.Remove(user);
                _userDbContext.SaveChanges();
            }        
        }
    }
}

