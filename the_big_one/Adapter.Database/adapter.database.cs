//   ADAPTER DATABASE
//   handles interactions with a database.
//   contains classes for database connection, querying, and data manipulation.


using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Adapter.Database
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserDatabase
    {
        private readonly string connectionString;
        public UserDatabase(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        
        public void AddUser(User user)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO users (userid, username, email, password) " +
                               "VALUES (@UserId, @UserName, @Email, @Password)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", user.UserId);
                    command.Parameters.AddWithValue("@UserName", user.UserName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.ExecuteNonQuery();
                }
            }
        }

        public User GetUser(int UserId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM users WHERE userid = @UserId";
                using (SqlCommand command = new SqlCommand(query,connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                UserId = Convert.ToInt32(reader["userid"]),
                                UserName = Convert.ToString(reader["username"]),
                                Email = Convert.ToString(reader["email"]),
                                Password = Convert.ToString(reader["password"])
                            };
                        }
                    }
                }
            }

            return null; // if user not found
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM users";

                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            UserId = Convert.ToInt32(reader["userid"]),
                            UserName = Convert.ToString(reader["username"]),
                            Email = Convert.ToString(reader["email"]),
                            Password = Convert.ToString(reader["password"])
                        });
                    }
                }
            }
            return users;
        }
    }
}

