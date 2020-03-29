namespace Fitness2You.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

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
