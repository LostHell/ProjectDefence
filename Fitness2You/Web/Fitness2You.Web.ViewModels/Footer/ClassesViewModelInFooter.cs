namespace Fitness2You.Web.ViewModels.Footer
{
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;

    public class ClassesViewModelInFooter : IMapFrom<Class>
    {
        public string Name { get; set; }
    }
}
