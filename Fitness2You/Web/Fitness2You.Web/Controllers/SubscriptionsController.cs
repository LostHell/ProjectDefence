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

        public async Task<IActionResult> OurSubsctiprions()
        {
            var subscriptions = await this.subscriptionsServices.GetAll();
            return this.View(subscriptions);
        }
    }
}
