using Adapter.Database;
using DomainApi;
using DomainApi.Models;
using DomainImpl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Web.Api
{
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

                bool shouldRun = true;
                while (shouldRun)
                {
                    Console.Write("______________________________________________\n" +
                                  "Choose one:" +
                                  "\n   0 = EXIT" +
                                  "\n   1 = CREATE     user: (sign up)" +
                                  "\n   2 = RETRIEVE   user: (log in)" +
                                  "\n   3 = UPDATE     user: (change password)" +
                                  "\n   4 = DELETE     user: (delete account)\n");
                    string? userInput = Console.ReadLine();


                    switch (userInput)
                    {
                        case "0":
                            Console.WriteLine("K, bye!");
                            shouldRun = false;
                            break;

                        case "1":
                            Console.WriteLine("Let's CREATE a new user.\n" +
                                              "Provide username: ");
                            string? iusername = Console.ReadLine();
                            Console.WriteLine("Provide email: ");
                            string? iemail = Console.ReadLine();
                            Console.WriteLine("Provide password: ");
                            string? ipassword = Console.ReadLine();

                            var newUser = new User
                            {
                                // userId = 23,
                                userName = iusername,
                                email = iemail,
                                password = ipassword
                            };
                            dbContext.Users.Add(newUser);
                            dbContext.SaveChanges();
                            Console.WriteLine($"User "+ iusername +" successfully added!\n");
                            break;

                        case "2":
                            Console.WriteLine("Provide email: ");
                            string emailToLogIn = Console.ReadLine();
                            Console.WriteLine("Provide password: ");
                            string passwordToLogIn = Console.ReadLine();
                            
                            var retrievedUser = dbContext.Users.FirstOrDefault(u => u.email == emailToLogIn && u.password == passwordToLogIn);
                            if (retrievedUser != null)
                            {
                                Console.WriteLine($"User ID: {retrievedUser.userId}, " +
                                                  $"Username: {retrievedUser.userName}, " +
                                                  $"Email: {retrievedUser.email}\n");
                            }
                            else
                            {
                                Console.WriteLine($"User '{emailToLogIn}' not found.");
                            }
                            break;

                        case "3":
                            Console.WriteLine("Provide username that u want to UPDATE:");
                            string usernameToUpdate = Console.ReadLine();

                            // Retrieve 
                            var userToUpdate = dbContext.Users.FirstOrDefault(u => u.userName == usernameToUpdate);
                            if (userToUpdate != null)
                            {
                                Console.WriteLine($"User '{usernameToUpdate}' found.");

                                Console.WriteLine("Provide new username (leave empty to keep current): ");
                                string newUsername = Console.ReadLine();
                                Console.WriteLine("Provide new email (leave empty to keep current): ");
                                string newEmail = Console.ReadLine();
                                Console.WriteLine("Provide new password (leave empty to keep current): ");
                                string newPassword = Console.ReadLine();

                                // Update 
                                if (!string.IsNullOrWhiteSpace(newUsername))
                                {
                                    userToUpdate.userName = newUsername;
                                }
                                if (!string.IsNullOrWhiteSpace(newEmail))
                                {
                                    userToUpdate.email = newEmail;
                                }
                                if (!string.IsNullOrWhiteSpace(newPassword))
                                {
                                    // Hash the new password before updating
                                    // userToUpdate.password = PasswordHasher.Hash(newPassword);
                                }

                                dbContext.SaveChanges();
                                Console.WriteLine($"User '{usernameToUpdate}' updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine($"User '{usernameToUpdate}' not found.");
                            }
                            break;
                        
                        case "4":
                            Console.WriteLine("Which user do you want to DELETE?");
                            string usernameToDelete = Console.ReadLine();

                            // Retrieve 
                            var userToDelete = dbContext.Users.FirstOrDefault(u => u.userName == usernameToDelete);
                            if (userToDelete != null)
                            {
                                Console.WriteLine($"User '{usernameToDelete}' found.");

                                Console.WriteLine($"Do you really really wanna delete user '{usernameToDelete}'? (Y/N)");
                                string confirmation = Console.ReadLine();
                                if (confirmation.ToUpper() == "Y")
                                {
                                    dbContext.Users.Remove(userToDelete);
                                    dbContext.SaveChanges();
                                    Console.WriteLine($"User '{usernameToDelete}' deleted successfully.");
                                }
                                else
                                {
                                    Console.WriteLine($"Deletion of user '{usernameToDelete}' canceled.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"User '{usernameToDelete}' not found.");
                            }
                            break;

                        default:
                            Console.WriteLine("Choose 0, 1, 2, 3, or 4 operation!");
                            break;
                    }
                }
            }
        }
    }
}
