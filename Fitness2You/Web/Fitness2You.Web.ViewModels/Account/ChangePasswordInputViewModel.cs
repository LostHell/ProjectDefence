namespace Fitness2You.Web.ViewModels.Account
{
    using System.ComponentModel.DataAnnotations;

    public class ChangePasswordInputViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "New Password is Required.")]
        [DataType(DataType.Password)]
        [StringLength(30, ErrorMessage = "Password must be between 6 and 30 characters long", MinimumLength = 6)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        [Display(Name = "Repeat password")]
        public string RepeatPassword { get; set; }
    }
}
