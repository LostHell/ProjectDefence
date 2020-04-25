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
                var homeView = new HomeViewModel();
                homeView.Benefits = await this.homeServices.GetAllBenefits();
                homeView.Newsletters = home.Newsletters;
                this.ModelState.AddModelError(string.Empty, "Invalid newsletter input data, check your FULLNAME and EMAIL!");
                return this.View(homeView);
            }

            await this.homeServices.SendNewsLetter(home.Newsletters);
            return this.Redirect("/");
        }

        public IActionResult Privacy()
        {
            return this.View();
        }
    }
}
