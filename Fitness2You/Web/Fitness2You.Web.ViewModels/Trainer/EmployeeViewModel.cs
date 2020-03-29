namespace Fitness2You.Web.ViewModels.Trainer
{
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;

    public class EmployeeViewModel : IMapFrom<Trainer>
    {
        public string Fullname { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public string Salary { get; set; }
    }
}
