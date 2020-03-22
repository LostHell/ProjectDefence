namespace Fitness2You.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : BaseController
    {
        public IActionResult Login()
        {
            return this.View();
        }

        public IActionResult Register()
        {
            return this.View();
        }
    }
}
