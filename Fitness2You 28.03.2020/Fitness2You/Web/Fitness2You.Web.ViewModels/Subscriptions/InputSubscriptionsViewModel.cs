namespace Fitness2You.Web.ViewModels.Subscriptions
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class InputSubscriptionsViewModel
    {
        [Required(ErrorMessage = "Name is required!")]
        [Display(Name = "Name")]
        [StringLength(100, ErrorMessageResourceName = "Subscription name must be between 4 and 100 symbols long!", MinimumLength = 4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        [Display(Name = "Description")]
        [StringLength(300, ErrorMessage = "Subscription description must be between 5 and 300 symbols long!", MinimumLength = 5)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required!")]
        [Display(Name = "Price")]
        [Range(0, 9999, ErrorMessage = "Subscription price must be between 0$ and 9999$ !")]
        public decimal Price { get; set; }

        [Display(Name = "Discount")]
        [Range(0, 999, ErrorMessage = "Subscription discount must be between 0$ and 999$ !")]
        public int? Discount { get; set; }

        [Required(ErrorMessage ="Image is required!")]
        [Url]
        public string ImagePath { get; set; }
    }
}
