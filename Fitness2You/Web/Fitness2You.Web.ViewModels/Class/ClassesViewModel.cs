namespace Fitness2You.Web.ViewModels.Class
{
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;

    public class ClassesViewModel : IMapFrom<Class>
    {
        public string ImageUrl { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string Discount { get; set; }

        public string IsActive { get; set; }
    }
}
