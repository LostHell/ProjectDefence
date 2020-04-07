namespace Fitness2You.Web.ViewModels.Home
{
    using System.ComponentModel.DataAnnotations;

    public class NewsletterInputViewModel
    {
        [Required(ErrorMessage = "Your name is Required!")]
        [StringLength(80, ErrorMessage = "Your name must be between 5 and 80 characters long!", MinimumLength = 5)]
        [Display(Name = "Your Name")]
        public string Fullname { get; set; }

        [Required(ErrorMessage = "Email address is Required!")]
        [EmailAddress]
        [StringLength(80, ErrorMessage = "Email address must be between 6 and 80 characters long!", MinimumLength = 6)]
        public string Email { get; set; }
    }
}
