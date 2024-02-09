namespace Adapter.Database
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class UserDatabase
    {
        private List<User> users = new List<User>();

        public void AddUser(User user)
        {
            user.UserId = users.Count + 1;
            users.Add(user);
        }

        public User GetUser(int userId)
        {
            return users.FirstOrDefault(u => u.UserId == userId);
        }

        public List<User> GetAllUsers()
        {
            return users.ToList();
        }
    }
}

