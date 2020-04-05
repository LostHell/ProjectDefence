namespace Fitness2You.Web.Controllers
{
    using System.Threading.Tasks;

    using Fitness2You.Services.Data.AdminServices;
    using Fitness2You.Web.ViewModels.Class;
    using Fitness2You.Web.ViewModels.Subscription;
    using Fitness2You.Web.ViewModels.Trainer;
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

        public IActionResult AddClass()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddClass(ClassesInputViewModel classes)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(classes);
            }

            await this.adminServices.AddNewClassAsync(classes);
            return this.Redirect("/AdminPanel/Classes");
        }

        public async Task<IActionResult> EditClass(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var currentClass = await this.adminServices.GetClassIdAsync(id);

            if (currentClass == null)
            {
                return this.NotFound();
            }

            return this.View(currentClass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditClass(int id, ClassesInputViewModel classes)
        {
            if (id != classes.Id)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(classes);
            }

            await this.adminServices.EditClassAsync(classes);
            return this.Redirect("/AdminPanel/Classes");
        }

        public async Task<IActionResult> DeleteClass(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var currentClass = await this.adminServices.GetClassIdAsync(id);
            if (currentClass == null)
            {
                return this.NotFound();
            }

            return this.View(currentClass);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteClass(int id, ClassesInputViewModel classes)
        {
            if (id != classes.Id)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                this.ModelState.AddModelError(string.Empty, "Sorry we cannot delete this Class!");
            }

            await this.adminServices.DeleteClassAsync(classes);
            return this.Redirect("/AdminPanel/Classes");
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

        public IActionResult AddEmployee()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(EmployeeInputViewModel employee)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(employee);
            }

            await this.adminServices.AddNewEmployeeAsync(employee);
            return this.Redirect("/AdminPanel/Employees");
        }

        public async Task<IActionResult> EditEmployee(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var employee = await this.adminServices.GetEmployeeIdAsync(id);

            if (employee == null)
            {
                return this.NotFound();
            }

            return this.View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEmployee(string id, EmployeeInputViewModel employee)
        {
            if (id != employee.Id)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(employee);
            }

            await this.adminServices.EditEmployeeAsync(employee);
            return this.Redirect("/AdminPanel/Employees");
        }

        public async Task<IActionResult> DeleteEmployee(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var employee = await this.adminServices.GetEmployeeIdAsync(id);

            if (employee == null)
            {
                return this.NotFound();
            }

            return this.View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEmployee(string id, EmployeeInputViewModel employee)
        {
            if (id != employee.Id)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                this.ModelState.AddModelError(string.Empty, "Sorry, but we can't find it this Employee!");
            }

            await this.adminServices.DeleteEmployeeAsync(employee);
            return this.Redirect("/AdminPanel/Employees");
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

            var subscription = await this.adminServices.GetSubscriptionIdAsync(id);
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

            await this.adminServices.EditSubscriptionAsync(subscriptions);
            return this.Redirect("/AdminPanel/Admin");
        }

        public async Task<IActionResult> DeleteSubscription(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var subscription = await this.adminServices.GetSubscriptionIdAsync(id);
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

            await this.adminServices.DeleteSubscriptionAsync(subscriptions);
            return this.Redirect("/AdminPanel/Admin");
        }
    }
}
