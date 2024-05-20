// User.cs

using System.ComponentModel.DataAnnotations;

namespace DomainApi.Models;

public class User
{
    public int UserID { get; set; }
    
    [Required]
    public string Username { get; set; }
    
    [Required, EmailAddress]
    public string Email { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}


