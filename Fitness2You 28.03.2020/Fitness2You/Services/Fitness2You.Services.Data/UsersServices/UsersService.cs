namespace Fitness2You.Services.Data.UsersService
{
    using System.Linq;
    using System.Threading.Tasks;

    using Fitness2You.Data.Common.Repositories;
    using Fitness2You.Data.Models;
    using Microsoft.AspNetCore.Identity;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IRepository<ApplicationRole> roleRepository;
        private readonly IRepository<IdentityUserRole<string>> userRoleRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UsersService(
            IDeletableEntityRepository<ApplicationUser> userRepository,
            IRepository<ApplicationRole> roleRepository,
            IRepository<IdentityUserRole<string>> userRoleRepository,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.userRoleRepository = userRoleRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task ChangePassword(string username, string oldPassword, string newPassword)
        {
            ApplicationUser user = this.userRepository.All().FirstOrDefault(x => x.UserName == username);
            var result = await this.userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            if (result.Succeeded)
            {
                return;
            }

            await this.signInManager.RefreshSignInAsync(user);
        }

        public bool EmailExists(string email)
        {
            return this.userRepository.All().Any(x => x.Email == email);
        }

        public async Task Login(string username, string password)
        {
            var result = await this.signInManager.PasswordSignInAsync(username, password, true, false);

            if (result.Succeeded)
            {
                return;
            }
        }

        public async Task Logout()
        {
            await this.signInManager.SignOutAsync();
        }

        public async Task Register(string username, string email, string phoneNumber, string password)
        {
            var user = new ApplicationUser
            {
                UserName = username,
                Email = email,
                PhoneNumber = phoneNumber,
            };

            var result = await this.userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return;
            }

            var userId = user.Id;

            await this.AddUserInRole(userId);
        }

        public bool UsernameExists(string username)
        {
            return this.userRepository.All().Any(x => x.UserName == username);
        }

        private async Task AddUserInRole(string id)
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
    }
}
