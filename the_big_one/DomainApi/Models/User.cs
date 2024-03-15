// User.cs

namespace DomainApi.Models;

public class User
{
    public int userId { get; set; }
    public string? userName { get; set; }
    public string? email { get; set; }
    public string? password { get; set; }
}
