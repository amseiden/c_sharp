//   WEB API

using Adapter.Database;
using DomainApi;
using DomainImpl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Api;

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

            // // EXAMPLE: Add user
            // var newUser = new User
            // {
            //     // userId = 23,
            //     userName = "UpdatedJohnDoe",
            //     email = "mars@acasa.com",
            //     password = "password123"
            // };
            // dbContext.Users.Add(newUser);
            // dbContext.SaveChanges();

            // // EXAMPLE: Retrieve all users
            // var allUsers = dbContext.Users.ToList();
            // foreach (var user in allUsers)
            // {
            //     Console.WriteLine($"User ID: {user.userId}, Username: {user.userName}");
            // }

            // // EXAMPLE: Update user
            // var userToUpdate = dbContext.Users.FirstOrDefault(u => u.userName == "UpdatedJohnDoe");
            // if (userToUpdate != null)
            // {
            //     userToUpdate.userName = "JohnDoe";
            //     dbContext.SaveChanges();
            // }
            
            
            // // EXAMPLE: Delete user
            // var userToDelete = dbContext.Users.FirstOrDefault(u => u.userName == "UpdatedJohnDoe");
            // if (userToDelete != null)
            // {
            //     dbContext.Users.Remove(userToDelete);
            //     dbContext.SaveChanges();
            // }

            Console.WriteLine("Database operations completed successfully!");
        }
    }
}