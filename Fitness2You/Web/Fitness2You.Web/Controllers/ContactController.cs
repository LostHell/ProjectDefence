namespace Fitness2You.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        public ContactController()
        {
        }

        public IActionResult ContactMe()
        {
            return this.View();
        }
    }
}
