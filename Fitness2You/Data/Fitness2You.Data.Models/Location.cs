namespace Fitness2You.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Fitness2You.Data.Common.Models;

    public class Location : BaseModel<int>
    {
        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longitude { get; set; }
    }
}
