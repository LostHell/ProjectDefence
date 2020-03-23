using Fitness2You.Data;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Fitness2You.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public UsersService(ApplicationDbContext db,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task ChangePassword(string username, string oldPassword, string newPassword)
        {
            IdentityUser user = db.Users.FirstOrDefault(x => x.UserName == username);
            var result = await userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            if (result.Succeeded)
            {
                
            }

            await signInManager.RefreshSignInAsync(user);
        }

        public bool EmailExists(string email)
        {
            return this.db.Users.Any(x => x.Email == email);
        }

        public async Task Login(string username, string password)
        {
            var result = await signInManager.PasswordSignInAsync(username, password, false, false);

            if (result.Succeeded)
            {

            }
        }

        public async Task Logout()
        {
            await signInManager.SignOutAsync();
        }

        public async Task Register(string username, string email, string password)
        {
            var user = new IdentityUser
            {
                UserName = username,
                Email = email,
            };

            var result = await userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {

            }
        }

        public bool UsernameExists(string username)
        {
            return this.db.Users.Any(x => x.UserName == username);
        }
    }
}
