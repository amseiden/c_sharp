using Adapter.Database;
using DomainImpl;

class Program
{
    static void Main()
    {
        var userDatabase = new UserDatabase();
        var userManager = new UserManager(userDatabase);

        var newUser = new User { UserName = "MaxMule" };
        userManager.AddUser(newUser);

        var retrievedUser = userManager.GetUser(1);
        Console.WriteLine($"User ID: {retrievedUser.UserId}, " +
                          $"UserName: {retrievedUser.UserName}");

        var allUsers = userManager.GetAllUsers();
        foreach (var user in allUsers)
        {
            Console.WriteLine($"User ID: {user.UserId}, " +
                              $"UserName: {user.UserName}");
        }
    }
}