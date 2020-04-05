namespace Fitness2You.Web.Controllers
{
    using System.Threading.Tasks;

    using Fitness2You.Data.Models;
    using Fitness2You.Services.Data.UserServices;
    using Fitness2You.Web.ViewModels.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(
            IUsersService usersService,
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            this.usersService = usersService;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputViewModel login)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(login);
            }

            var userLogin = await this.signInManager.PasswordSignInAsync(login.Username, login.Password, true, false);

            if (!userLogin.Succeeded)
            {
                this.ModelState.AddModelError(string.Empty, "Invalid Username or password!");
                return this.View(login);
            }

            return this.LocalRedirect("~/");
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterInputViewModel register)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(register);
            }

            if (this.usersService.UsernameExists(register.Username))
            {
                this.ModelState.AddModelError(string.Empty, "Username already exists!");
                return this.View(register);
            }

            if (this.usersService.EmailExists(register.Email))
            {
                this.ModelState.AddModelError(string.Empty, "Email address already exists!");
                return this.View(register);
            }

            var user = new ApplicationUser
            {
                UserName = register.Username,
                Email = register.Email,
                PhoneNumber = register.PhoneNumber,
            };

            await this.userManager.CreateAsync(user, register.Password);
            await this.usersService.AddUserInRole(user.Id);

            return this.Redirect("/Users/Login");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();
            return this.Redirect("/");
        }
    }
}
