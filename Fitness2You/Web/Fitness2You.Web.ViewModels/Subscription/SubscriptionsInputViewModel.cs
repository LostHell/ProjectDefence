namespace Fitness2You.Web.ViewModels.Subscription
{
    using System.ComponentModel.DataAnnotations;

    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;

    public class SubscriptionsInputViewModel : IMapFrom<Subscription>
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Image Url")]
        [Url]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Subscription name must be between 6 and 100 symbols long!", MinimumLength = 6)]
        public string Name { get; set; }

        [Required]
        [Range(0, 9999, ErrorMessage = "Subscription price must be between 0 and 9999!")]
        public decimal Price { get; set; }

        [Range(0, 100, ErrorMessage = "Discount Percent must be between 0% and 100%!")]
        public int? Discount { get; set; }

        [Required(ErrorMessage = "Active must be True or False!")]
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
    }
}
