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
                .AddScoped<IPasswordHasher, PasswordHasher>()
                .AddScoped<IUserManager, UserManager>()
                .AddDbContext<UserDbContext>(options =>
                    options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                        new MySqlServerVersion(new Version(5, 7, 39))))
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
                            Console.WriteLine("K, BYE!");
                            shouldRun = false;
                            break;

                        case "1":
                            Console.WriteLine("SIGN UP\n" +
                                              "Provide username: ");
                            string? iusername = Console.ReadLine();
                            Console.WriteLine("Provide email: ");
                            string? iemail = Console.ReadLine();
                            Console.WriteLine("Provide password: ");
                            string? ipassword = Console.ReadLine();
    
                            var passwordHasher = new PasswordHasher();
                            string hashedPassword = passwordHasher.Hash(ipassword);

                            var newUser = new User
                            {
                                userName = iusername,
                                email = iemail,
                                password = hashedPassword 
                            };
    
                            dbContext.Users.Add(newUser);
                            dbContext.SaveChanges();
                            Console.WriteLine($"User {iusername} successfully added!\n");
                            break;


                        case "2":
                            Console.WriteLine("LOG IN\n" +
                                              "Provide email: ");
                            string? inputEmail = Console.ReadLine();
                            Console.WriteLine("Provide password: ");
                            string? inputPassword = Console.ReadLine();

                            var retrievedUser2 = dbContext.Users.FirstOrDefault(u => u.email == inputEmail);

                            var newPasswordHasher = new PasswordHasher();
                            if (retrievedUser2 != null && newPasswordHasher.Verify(retrievedUser2.password,inputPassword ))
                            {
                                Console.WriteLine($"User '{retrievedUser2.userName}' LOGGED IN");
                            }
                            else
                            {
                                Console.WriteLine("Invalid email or password.");
                            }
                            break;

                        case "3":
                            Console.WriteLine("Provide username of the user that u want to UPDATE:");
                            string? usernameToUpdate = Console.ReadLine();

                            var userToUpdate = dbContext.Users.FirstOrDefault(u => u.userName == usernameToUpdate);
                            if (userToUpdate != null)
                            {
                                Console.WriteLine($"User '{usernameToUpdate}' found.");

                                Console.WriteLine("Provide new username (leave empty to keep current): ");
                                string? newUsername = Console.ReadLine();
                                Console.WriteLine("Provide new email (leave empty to keep current): ");
                                string? newEmail = Console.ReadLine();
                                Console.WriteLine("Provide new password (leave empty to keep current): ");
                                string? newPassword = Console.ReadLine();

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
                                    var myPasswordHasher = new PasswordHasher();
                                    userToUpdate.password = myPasswordHasher.Hash(newPassword);                                    
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
                            Console.WriteLine("Provide userName that you want to DELETE");
                            string? usernameToDelete = Console.ReadLine();
                            var userToDelete = dbContext.Users.FirstOrDefault(u => u.userName == usernameToDelete);
                            if (userToDelete != null)
                            {
                                string confirmation;
                                do
                                {
                                    Console.WriteLine($"Do you really really wanna delete user '{usernameToDelete}'? (Y/N)");
                                    confirmation = Console.ReadLine().ToUpper();
                                } while (confirmation != "Y" && confirmation != "N");

                                if (confirmation == "Y")
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
