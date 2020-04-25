namespace Fitness2You.Web.ViewModels.Home
{
    using System.ComponentModel.DataAnnotations;

    public class NewsletterInputViewModel
    {
        [Required(ErrorMessage = "Your name is Required!")]
        [StringLength(80, ErrorMessage = "Your name must be between 5 and 80 characters long!", MinimumLength = 5)]
        [RegularExpression(@"^[A-z]{3,15}\ [A-z]{3,20}$", ErrorMessage ="Enter valid names!")]
        [Display(Name = "Your Name")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Email address is Required!")]
        [EmailAddress]
        [RegularExpression(@"^[A-z0-9\.]{3,30}\@[A-z]{3,11}\.[A-z]{2,7}$", ErrorMessage = "Invalid Email address!")]
        [StringLength(80, ErrorMessage = "Email address must be between 6 and 80 characters long!", MinimumLength = 6)]
        public string Email { get; set; }
    }
}
