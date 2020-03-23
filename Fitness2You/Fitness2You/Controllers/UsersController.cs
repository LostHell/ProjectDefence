using Fitness2You.Services;
using Fitness2You.ViewModels.Users;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fitness2You.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginInputViewModel login)
        {
            await usersService.Login(login.Username, login.Password);
            return LocalRedirect("~/");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterInputViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            if (usersService.UsernameExists(register.Username))
            {
                ModelState.AddModelError(string.Empty, "Username is already exist!");
                return View(register);
            }
            if (usersService.EmailExists(register.Email))
            {
                ModelState.AddModelError(string.Empty, "Email address is already exist!");
                return View(register);
            }

            await usersService.Register(register.Username, register.Email, register.Password);

            return Redirect("/Users/Login");
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            await usersService.Logout();
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return Redirect("/");
            }
        }
    }
}
