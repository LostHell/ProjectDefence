namespace Fitness2You.Web.Controllers
{
    using System.Threading.Tasks;

    using Fitness2You.Services.Data.UsersService;
    using Fitness2You.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : BaseController
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
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

            await this.usersService.Login(login.Username, login.Password);
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

            await this.usersService.Register(register.Username, register.Email, register.PhoneNumber, register.Password);

            return this.Redirect("/Users/Login");
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordInputViewModel password)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.usersService.ChangePassword(this.User.Identity.Name, password.OldPassword, password.NewPassword);
            return this.Redirect("/Home/Index");
        }

        public async Task<IActionResult> Logout()
        {
            await this.usersService.Logout();

            // return this.LocalRedirect("/");
            return this.Redirect("/");
        }
    }
}
