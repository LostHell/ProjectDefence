namespace Fitness2You.Web.Controllers
{
    using System.Threading.Tasks;

    using Fitness2You.Services.Data.SubscriptionsServices;
    using Fitness2You.Web.ViewModels.Subscription;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class SubscriptionsController : Controller
    {
        private readonly ISubscriptionsServices subscriptionsServices;

        public SubscriptionsController(ISubscriptionsServices subscriptionsServices)
        {
            this.subscriptionsServices = subscriptionsServices;
        }

        public async Task<IActionResult> OurSubsctiprions()
        {
            var subscriptions = await this.subscriptionsServices.GetAll();
            return this.View(subscriptions);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AddSubscription()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddSubscription(SubscriptionsInputViewModel subscriptions)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(subscriptions);
            }

            await this.subscriptionsServices.AddNewSubscriptionAsync(subscriptions);
            return this.Redirect("/Subscriptions/OurSubsctiprions");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditSubscription(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var subscription = await this.subscriptionsServices.GetIdAsync(id);
            if (subscription == null)
            {
                return this.NotFound();
            }

            return this.View(subscription);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSubscription(int id, SubscriptionsInputViewModel subscriptions)
        {
            if (id != subscriptions.Id)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(subscriptions);
            }

            await this.subscriptionsServices.EditAsync(subscriptions);
            return this.Redirect("/Account/AdminPanel");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSubscription(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var subscription = await this.subscriptionsServices.GetIdAsync(id);
            if (subscription == null)
            {
                return this.NotFound();
            }

            return this.View(subscription);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteSubscription(int id, SubscriptionsInputViewModel subscriptions)
        {
            if (id != subscriptions.Id)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                this.ModelState.AddModelError(string.Empty, "Sorry we cannot delete this Item!");
            }

            await this.subscriptionsServices.DeleteAsync(subscriptions);
            return this.Redirect("/Account/AdminPanel");
        }
    }
}
