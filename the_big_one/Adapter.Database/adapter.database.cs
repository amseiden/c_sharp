﻿//   ADAPTER DATABASE

using DomainApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Adapter.Database
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
            // dependency injection here
        }
    }
}

