namespace Fitness2You.Web.Controllers
{
    using System.Threading.Tasks;

    using Fitness2You.Services.Data.AccountServices;
    using Fitness2You.Web.ViewModels.Subscription;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private readonly IAdminServices adminServices;

        public AdminPanelController(IAdminServices adminServices)
        {
            this.adminServices = adminServices;
        }

        public async Task<IActionResult> Admin()
        {
            var subscriptions = await this.adminServices.GetSubscriptions();
            return this.View(subscriptions);
        }

        public async Task<IActionResult> Classes()
        {
            var classes = await this.adminServices.GetClasses();
            return this.View(classes);
        }

        public async Task<IActionResult> AllUser()
        {
            var users = await this.adminServices.GetAllUsers();

            return this.View(users);
        }

        public async Task<IActionResult> Employees()
        {
            var trainers = await this.adminServices.GetEmployees();
            return this.View(trainers);
        }

        public IActionResult ContactMe()
        {
            return this.View();
        }

        public IActionResult AddSubscription()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddSubscription(SubscriptionsInputViewModel subscriptions)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(subscriptions);
            }

            await this.adminServices.AddNewSubscriptionAsync(subscriptions);
            return this.Redirect("/AdminPanel/Admin");
        }

        public async Task<IActionResult> EditSubscription(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var subscription = await this.adminServices.GetIdAsync(id);
            if (subscription == null)
            {
                return this.NotFound();
            }

            return this.View(subscription);
        }

        [HttpPost]
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

            await this.adminServices.EditAsync(subscriptions);
            return this.Redirect("/AdminPanel/Admin");
        }

        public async Task<IActionResult> DeleteSubscription(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var subscription = await this.adminServices.GetIdAsync(id);
            if (subscription == null)
            {
                return this.NotFound();
            }

            return this.View(subscription);
        }

        [HttpPost]
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

            await this.adminServices.DeleteAsync(subscriptions);
            return this.Redirect("/AdminPanel/Admin");
        }
    }
}
