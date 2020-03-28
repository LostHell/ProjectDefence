namespace Fitness2You.Web.Controllers
{
    using Fitness2You.Services.Data.F2YServices;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Admin")]
    public class F2YController : BaseController
    {
        private readonly IF2YService service;

        public F2YController(IF2YService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return this.View(this.service.All());
        }
    }
}
