//   DOMAIN IMPL
//   IUserManager

using Adapter.Database;
using DomainApi;
using DomainApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DomainImpl
{
    public class UserManager : IUserManager
    {
        private readonly UserDbContext _userDbContext;
        private readonly IPasswordHasher _passwordHasher;

        public UserManager(UserDbContext userDbContext, IPasswordHasher passwordHasher)
        {
            this._userDbContext = userDbContext ?? throw new ArgumentNullException(nameof(userDbContext));
            this._passwordHasher = passwordHasher ?? throw new ArgumentNullException(nameof(passwordHasher));
        }
        
        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            using (var transaction = _userDbContext.Database.BeginTransaction())
            {
                try
                {
                    user.Password = _passwordHasher.Hash(user.Password);
                    _userDbContext.Users.Add(user);
                    _userDbContext.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
        
        public User GetUser(int userName)
        {
            return _userDbContext.Users.Find(userName);
        }
        public List<User> GetAllUsers()
        {
            return _userDbContext.Users.ToList();
        }

        public void UpdateUser(int userId, string? username, string? email, string? password, string? firstName, string? lastName)
        {
            var user = _userDbContext.Users.Find(userId);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(username)) user.Username = username;
                if (!string.IsNullOrEmpty(email)) user.Email = email;
                if (!string.IsNullOrEmpty(password)) user.Password = _passwordHasher.Hash(password); // hash the password
                if (!string.IsNullOrEmpty(firstName)) user.FirstName = firstName;
                if (!string.IsNullOrEmpty(lastName)) user.LastName = lastName;

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
        
        public async Task<User> VerifyCredentialsAsync(string username, string password)
        {
            var user = await _userDbContext.Users.SingleOrDefaultAsync(u => u.Username == username);
            if (user != null && _passwordHasher.Verify(user.Password, password))
            {
                return user;
            }

            return null;
        }

    }
}

