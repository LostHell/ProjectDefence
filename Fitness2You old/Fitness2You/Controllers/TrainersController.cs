using Microsoft.AspNetCore.Mvc;

namespace Fitness2You.Controllers
{
    public class TrainersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
