namespace Fitness2You.Web.ViewModels.Home
{
    using System.ComponentModel.DataAnnotations;

    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;

    public class BenefitsViewModel : IMapFrom<Benefit>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public bool IsActive { get; set; }
    }
}
