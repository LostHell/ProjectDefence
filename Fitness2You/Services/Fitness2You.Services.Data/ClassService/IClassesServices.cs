namespace Fitness2You.Services.Data.ClassService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Web.ViewModels.Class;

    public interface IClassesServices
    {
        Task<IList<ClassesInputViewModel>> GetClasses();
    }
}
