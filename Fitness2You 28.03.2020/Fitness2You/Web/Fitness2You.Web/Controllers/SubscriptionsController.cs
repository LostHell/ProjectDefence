namespace Fitness2You.Web.Controllers
{
    using System.Threading.Tasks;

    using Fitness2You.Services.Data.SubscriptionsService;
    using Fitness2You.Web.ViewModels.Subscriptions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class SubscriptionsController : BaseController
    {
        private readonly ISubscriptionsService subscriptionsService;

        public SubscriptionsController(ISubscriptionsService subscriptionsService)
        {
            this.subscriptionsService = subscriptionsService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult AddNew()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddNew(InputSubscriptionsViewModel input)
        {
            if (this.subscriptionsService.ExistName(input.Name))
            {
                this.ModelState.AddModelError(string.Empty, "Subscription name is already exist, please try agin!");
                return this.View();
            }

            var newSubscr = new InputSubscriptionsViewModel
            {
                Name = input.Name,
                Description = input.Description,
                Price = input.Price,
                Discount = input.Discount,
                ImagePath = input.ImagePath,
            };

            if (!this.ModelState.IsValid)
            {
                this.ModelState.AddModelError(string.Empty, "Please try again!");
                return this.View(newSubscr);
            }

            await this.subscriptionsService.AddSubscription(newSubscr);

            return this.Redirect("/F2Y/Index");
        }
    }
}
