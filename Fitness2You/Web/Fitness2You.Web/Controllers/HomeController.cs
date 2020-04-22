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

        public async Task<IActionResult> Index()
        {
            var benefits = new HomeViewModel();
            benefits.Benefits = await this.homeServices.GetAllBenefits();
            return this.View(benefits);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(HomeViewModel home)
        {
            if (!this.ModelState.IsValid)
            {
                this.ModelState.AddModelError(string.Empty, "Invalid newsletter input data!");
                return this.View(home.Newsletters);
            }

            await this.homeServices.SendNewsLetter(home.Newsletters);
            return this.Redirect("/");
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        public IActionResult Location()
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
