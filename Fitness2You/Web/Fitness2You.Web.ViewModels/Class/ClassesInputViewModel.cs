namespace Fitness2You.Web.ViewModels.Class
{
    using System.ComponentModel.DataAnnotations;

    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;

    public class ClassesInputViewModel : IMapFrom<Class>
    {
        public int Id { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Name is Required!")]
        [StringLength(50, ErrorMessage = "Class name must be between 4 and 50 characters long!", MinimumLength = 4)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Price is Required!")]
        [Range(0, 9999, ErrorMessage = "Price must be between 0$ and 9999$!")]
        public decimal Price { get; set; }

        [Range(0, 100, ErrorMessage = "Discount percent must be between 0% and 100%!")]
        public int? Discount { get; set; }

        [Required(ErrorMessage = "Active must be True or False!")]
        public bool IsActive { get; set; }
    }
}
