using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class SignUpViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        // [EmailAddress]
        public string Email { get; set; }

        [Required]
        // [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        // [DataType(DataType.Password)]
        // [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}