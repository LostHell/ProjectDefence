namespace Fitness2You.Services.Data.ClassService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fitness2You.Data.Common.Repositories;
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;
    using Fitness2You.Web.ViewModels.Class;
    using Microsoft.EntityFrameworkCore;

    public class ClassesServices : IClassesServices
    {
        private readonly IRepository<ApplicationUser> userRepository;
        private readonly IRepository<Class> classRepository;
        private readonly IRepository<UserClass> userClassRepository;

        public ClassesServices(
            IRepository<ApplicationUser> userRepository,
            IRepository<Class> classRepository,
            IRepository<UserClass> userClassRepository)
        {
            this.userRepository = userRepository;
            this.classRepository = classRepository;
            this.userClassRepository = userClassRepository;
        }

        public async Task AddUserToClass(int id, string username)
        {
            var user = this.userRepository.All().FirstOrDefault(x => x.UserName == username);

            var userToClass = new UserClass()
            {
                ClassId = id,
                UserId = user.Id,
                TakeOn = DateTime.UtcNow,
            };

            await this.userClassRepository.AddAsync(userToClass);
            await this.userClassRepository.SaveChangesAsync();
        }

        public async Task<IList<ClassesInputViewModel>> GetClasses()
        {
            var allClasses = await this.classRepository.All().To<ClassesInputViewModel>().ToListAsync();

            return allClasses;
        }
    }
}
