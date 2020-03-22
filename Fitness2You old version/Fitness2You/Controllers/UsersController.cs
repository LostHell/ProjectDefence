using Fitness2You.Services;
using Fitness2You.ViewModels.UsersInputModels;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Login(LoginInputViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.View(input);
            }

            return Redirect("/");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterInputViewModel input)
        {
            if (!ModelState.IsValid)
            {
                return this.View(input);
            }
            if (usersService.ExistsUser(input.Username))
            {
                ModelState.AddModelError("","Username is already exist!");
                return this.View(input);
            }

            usersService.Register(input.Username, input.Email, input.Password);

            return Redirect("/Users/Login");
        }
    }
}