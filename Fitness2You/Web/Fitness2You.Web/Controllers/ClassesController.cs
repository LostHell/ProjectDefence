namespace Fitness2You.Web.Controllers
{
    using System.Threading.Tasks;

    using Fitness2You.Services.Data.ClassService;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class ClassesController : Controller
    {
        private readonly IClassesServices classesServices;

        public ClassesController(IClassesServices classesServices)
        {
            this.classesServices = classesServices;
        }

        public async Task<IActionResult> OurClasses()
        {
            var classes = await this.classesServices.GetClasses();
            return this.View(classes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OurClasses(int? id)
        {
            var username = this.User.Identity.Name;

            if (id == null || username == null)
            {
                return this.NotFound();
            }

            await this.classesServices.AddUserToClass((int)id, username);
            return this.Redirect("/Account/MyAccount");
        }
    }
}
