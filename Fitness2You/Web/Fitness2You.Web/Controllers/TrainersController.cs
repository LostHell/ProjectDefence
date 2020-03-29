namespace Fitness2You.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class TrainersController : Controller
    {
        public TrainersController()
        {
        }

        public IActionResult OurTrainers()
        {
            return this.View();
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Employees()
        {
            return this.View();
        }
    }
}
