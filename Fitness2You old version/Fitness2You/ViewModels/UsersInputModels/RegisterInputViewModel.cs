using System.ComponentModel.DataAnnotations;

namespace Fitness2You.ViewModels.UsersInputModels
{
    public class RegisterInputViewModel
    {
        [Required(ErrorMessage = "Username is required!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Username, must be between 5 and 50 characters long!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required!")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Email, must be between 5 and 50 characters long")]
        [EmailAddress(ErrorMessage = "Sorry, Email is not valid!")]
        public string Email { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Password, must be between 6 and 200 characters long!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repeat password is required!")]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }
    }
}
