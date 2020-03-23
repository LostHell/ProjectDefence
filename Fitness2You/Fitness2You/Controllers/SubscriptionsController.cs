using Microsoft.AspNetCore.Mvc;

namespace Fitness2You.Controllers
{
    public class SubscriptionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
