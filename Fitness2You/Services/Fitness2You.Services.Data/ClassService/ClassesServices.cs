namespace Fitness2You.Services.Data.ClassService
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Data.Common.Repositories;
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;
    using Fitness2You.Web.ViewModels.Class;
    using Microsoft.EntityFrameworkCore;

    public class ClassesServices : IClassesServices
    {
        private readonly IRepository<Class> repositoryClass;

        public ClassesServices(IRepository<Class> repositoryClass)
        {
            this.repositoryClass = repositoryClass;
        }

        public async Task<IList<ClassesInputViewModel>> GetClasses()
        {
            var allClasses = await this.repositoryClass.All().To<ClassesInputViewModel>().ToListAsync();

            return allClasses;
        }
    }
}
