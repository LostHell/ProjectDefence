namespace Fitness2You.Services.Data.UserServices
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Fitness2You.Data.Common.Repositories;
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;
    using Fitness2You.Web.ViewModels.User;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IRepository<ApplicationRole> roleRepository;
        private readonly IRepository<IdentityUserRole<string>> userRoleRepository;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IRepository<ApplicationRole> roleRepository,
            IRepository<IdentityUserRole<string>> userRoleRepository)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.userRoleRepository = userRoleRepository;
        }

        public async Task AddUserInRole(string id)
        {
            var role = this.roleRepository.All().FirstOrDefault(x => x.Name == "User");

            var userInRole = new IdentityUserRole<string>
            {
                UserId = id,
                RoleId = role.Id,
            };

            await this.userRoleRepository.AddAsync(userInRole);
            await this.userRoleRepository.SaveChangesAsync();
        }

        public bool EmailExists(string email)
        {
            return this.userRepository.All().Any(x => x.Email == email);
        }

        public async Task<IList<AllUserViewModel>> GetAllUsers()
        {
            var allUsers = await this.userRepository.All().To<AllUserViewModel>().ToListAsync();

            return allUsers;
        }

        public bool UsernameExists(string username)
        {
            return this.userRepository.All().Any(x => x.UserName == username);
        }
    }
}
