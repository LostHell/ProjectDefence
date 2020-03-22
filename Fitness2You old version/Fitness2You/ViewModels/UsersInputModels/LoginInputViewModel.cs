using System.ComponentModel.DataAnnotations;

namespace Fitness2You.ViewModels.UsersInputModels
{
    public class LoginInputViewModel
    {
        [Required(ErrorMessage = "Username is required!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Username is incorrect.")]
        public string Username { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Password is incorrect.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
