namespace Fitness2You.Services.Data.F2YServices
{
    using System.Collections.Generic;
    using System.Linq;

    using Fitness2You.Data.Common.Repositories;
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;
    using Fitness2You.Web.ViewModels.F2Y;

    public class F2YService : IF2YService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public F2YService(IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public IEnumerable<UsersViewModel> All()
        {
            var result = this.userRepository.All().To<UsersViewModel>().ToList();
            return result;
        }
    }
}
