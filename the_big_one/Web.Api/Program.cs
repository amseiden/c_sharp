//   WEB API
//   the entry point of the proj interacts with the other components, orchestrating the flow of the program.
//   used to test and showcase the functionalities implemented in "DomainImpl.


using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Adapter.Database;  
using DomainApi;
using DomainImpl;

class Program
{
    static void Main()
    {
        // Setup DI (Dependency Injection)
        var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json");
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IConfiguration>(configuration as IConfiguration)
            .AddTransient<UserDatabase>()
            .AddTransient<IUserManager, UserManager>() 
            .BuildServiceProvider(); 
        // Resolve UserManager and UserDatabase from DI
        var userManager = serviceProvider.GetRequiredService<IUserManager>();
        var userDatabase = serviceProvider.GetRequiredService<UserDatabase>();

        // Example: Add a new user
        var newUser = new Adapter.Database.User { UserName = "MaxMule", Email = "maxmule@gmail.com", Password = "parolalalala" };
        userManager.AddUser(newUser);

        // Example: Retrieve and display a specific user
        var retrievedUser = userManager.GetUser(1);
        if (retrievedUser != null)
        {
            Console.WriteLine($"User ID: {retrievedUser.UserId}, " +
                              $"UserName: {retrievedUser.UserName}, " +
                              $"Email: {retrievedUser.Email}");
        }
        
        // Example: Retrieve and display all users
        var allUsers = userManager.GetAllUsers();
        foreach (var user in allUsers)
        {
            Console.WriteLine($"User ID: {user.UserId}, " +
                              $"UserName: {user.UserName}, " +
                              $"Email: {user.Email}");
        }
    }
}

internal class ConfigurationBuilder
{
    public object AddJsonFile(string appsettingsjson) 
    {
        throw new NotImplementedException();
    }
}

