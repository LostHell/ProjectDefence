namespace Fitness2You.Web.ViewModels.Trainer
{
    using System.ComponentModel.DataAnnotations;

    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;

    public class EmployeeInputViewModel : IMapFrom<Trainer>
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Fullname is Required!")]
        [RegularExpression(@"^[A-z]{3,}\ [A-z]{4,}$", ErrorMessage = "Fullname must be between 6 and 80 characters long!")]
        [MaxLength(80, ErrorMessage = "Fullname must be maximum 80 characters long!")]
        public string Fullname { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Title is Required!")]
        [StringLength(100, ErrorMessage = "Employee Title must be between 5 and 100 characters long!", MinimumLength = 5)]
        public string Title { get; set; }

        [Required]
        [Range(0, 10000, ErrorMessage = "Salary must be between 0$ and 10 000$")]
        public decimal Salary { get; set; }
    }
}
