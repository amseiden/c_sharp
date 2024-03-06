//   WEB API

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Adapter.Database;
using DomainApi;
using DomainApi.Models;
using DomainImpl;

class Program
{
    static void Main()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();

        var serviceProvider = new ServiceCollection()
            .AddDbContext<UserDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(5, 7, 39)) 
                )
            )
            .AddScoped<IUserManager, UserManager>()
            .BuildServiceProvider();

        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<UserDbContext>();

            // Example: Add user
            var newUser = new User
            {
                userName = "JohnDoe",
                email = "john.doe@example.com",
                password = "password123"
            };
            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();

            // Example: Retrieve all users
            var allUsers = dbContext.Users.ToList();
            foreach (var user in allUsers)
            {
                Console.WriteLine($"User ID: {user.userId}, Username: {user.userName}");
            }

            // Example: Update user
            var userToUpdate = dbContext.Users.FirstOrDefault(u => u.userName == "JohnDoe");
            if (userToUpdate != null)
            {
                userToUpdate.userName = "UpdatedJohnDoe";
                dbContext.SaveChanges();
            }

            // Example: Delete user
            var userToDelete = dbContext.Users.FirstOrDefault(u => u.userName == "UpdatedJohnDoe");
            if (userToDelete != null)
            {
                dbContext.Users.Remove(userToDelete);
                dbContext.SaveChanges();
            }

            Console.WriteLine("Database operations completed successfully!");
        }
    }
}
