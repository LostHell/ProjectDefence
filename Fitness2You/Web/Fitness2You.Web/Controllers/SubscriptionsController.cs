namespace Fitness2You.Web.Controllers
{
    using System.Threading.Tasks;

    using Fitness2You.Services.Data.SubscriptionsServices;
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

        public async Task<IActionResult> OurSubscriptions()
        {
            var subscriptions = await this.subscriptionsServices.GetAll();
            return this.View(subscriptions);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> OurSubscriptions(int? id)
        {
            var username = this.User.Identity.Name;

            if (id == null || username == null)
            {
                return this.NotFound();
            }

            var subsInfo = await this.subscriptionsServices.AddUserToSubscription((int)id, username);

            if (subsInfo == "You have this Subscription!")
            {
                return this.Redirect("/Subscriptions/OurSubscriptions");
            }

            return this.Redirect("/Account/MyAccount");
        }
    }
}
