//   ADAPTER DATABASE

using DomainApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Adapter.Database
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;
        public UserDbContext() { }
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            // dependency injection here
        }
    }
}

