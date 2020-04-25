namespace Fitness2You.Web.ViewModels.Locations
{
    using System.ComponentModel.DataAnnotations;

    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;

    public class LocationInputViewModel : IMapFrom<Location>
    {
        public int Id { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }
    }
}
