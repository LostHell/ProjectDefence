namespace Fitness2You.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class TrainersController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
