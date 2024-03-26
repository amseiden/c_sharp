//   DOMAIN IMPL

using System.Security.Cryptography;
using System.Text;
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

        public User GetUser(int userId)
        {
            return _userDbContext.Users.Find(userId);
        }
        public List<User> GetAllUsers()
        {
            return _userDbContext.Users.ToList();
        }

        public void UpdateUser(int userId, string? userName, string? email, string? password)
        {
            var user = _userDbContext.Users.Find(userId);
            if (user != null)
            {
                user.userName = userName;
                user.email = email;
                user.password = password;

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
    
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hashedBytes.Length; i++)
                {
                    stringBuilder.Append(hashedBytes[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }

        public bool Verify(string passwordHash, string inputPassword)
        {
            string inputHash = Hash(inputPassword);
            return string.Equals(passwordHash, inputHash, StringComparison.OrdinalIgnoreCase);
        }

    }
}

