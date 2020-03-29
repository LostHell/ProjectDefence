using System.ComponentModel.DataAnnotations;

namespace Fitness2You.ViewModels.Users
{
    public class RegisterInputViewModel
    {
        [Required(ErrorMessage = "Username is Required.")]
        [Display(Name = "Username")]
        [StringLength(30, ErrorMessage = "Username must be between 5 and 30 characters long.", MinimumLength = 5)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email address is Required.")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is Required.")]
        [Phone]
        [StringLength(20, MinimumLength = 6)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Password must be between 6 and 30 characters long", MinimumLength = 6)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Repeat Password is Required.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RepeatPassword { get; set; }
    }
}
