namespace Fitness2You.Web.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;

    using Fitness2You.Services.Data.HomeServices;
    using Fitness2You.Web.ViewModels;
    using Fitness2You.Web.ViewModels.Home;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IHomeServices homeServices;

        public HomeController(IHomeServices homeServices)
        {
            this.homeServices = homeServices;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(NewsletterInputViewModel newsletter)
        {
            if (!this.ModelState.IsValid)
            {
                this.ModelState.AddModelError(string.Empty, "Invalid newsletter input data!");
                return this.View(newsletter);
            }

            await this.homeServices.SendNewsLetter(newsletter);
            return this.Redirect("/");
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
