using System.ComponentModel.DataAnnotations;
namespace WebApp.Models;

public class LoginViewModel
{
    public LoginViewModel(string username, string password)
    {
        Username = username;
        Password = password;
    }

    [Required]
    public string Username { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}