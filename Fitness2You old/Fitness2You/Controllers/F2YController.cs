using Fitness2You.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fitness2You.Controllers
{
    public class F2YController : Controller
    {
        private readonly IF2YService service;

        public F2YController(IF2YService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View(service.All());
        }
    }
}
