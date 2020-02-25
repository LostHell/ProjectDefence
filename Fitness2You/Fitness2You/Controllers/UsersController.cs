using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fitness2You.Services;
using Fitness2You.ViewModels.Users;
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
        public IActionResult Login(LoginInputViewModel input)
        {
            if (this.User != null)
            {
                this.Login();
                return this.Redirect("/");
            }
            return this.View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterInputViewModel input)
        {
            if (input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Content("Password must be between 6 and 20 symbols!");
            }
            if (input.Password != input.ConfirmPassword)
            {
                return this.Content("Password must be the same!");
            }
            if (this.usersService.EmailExists(input.Email))
            {
                return this.Content("Email is already exits, please try again!");
            }
            if (this.usersService.UsernameExists(input.Username))
            {
                return this.Content("Username is alredy exist, please try again!");
            }

            usersService.Register(input.Username, input.Email, input.Password);
            return this.Redirect("/Users/Login");
        }
    }
}