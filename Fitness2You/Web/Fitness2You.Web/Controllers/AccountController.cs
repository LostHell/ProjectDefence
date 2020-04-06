namespace Fitness2You.Web.Controllers
{
    using System.Threading.Tasks;

    using Fitness2You.Data.Models;
    using Fitness2You.Services.Data.AccountServices;
    using Fitness2You.Web.ViewModels.Account;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAccountServices accountServices;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(
            IAccountServices accountServices,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.accountServices = accountServices;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> MyAccount()
        {
            MyAccountInputViewModel view = new MyAccountInputViewModel();
            view.UserSubscription = await this.accountServices.GetUserSubscriptions();
            view.UserClass = await this.accountServices.GetUserClasses();
            return this.View(view);
        }

        public IActionResult ChangePassword()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordInputViewModel changePassword)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var user = await this.userManager.GetUserAsync(this.User);
            await this.userManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.NewPassword);

            await this.signInManager.RefreshSignInAsync(user);
            return this.Redirect("/Home/Index");
        }
    }
}
