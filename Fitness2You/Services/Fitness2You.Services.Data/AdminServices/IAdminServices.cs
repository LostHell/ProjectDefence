namespace Fitness2You.Services.Data.AdminServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Data.Models;
    using Fitness2You.Web.ViewModels.Class;
    using Fitness2You.Web.ViewModels.Subscription;
    using Fitness2You.Web.ViewModels.Trainer;
    using Fitness2You.Web.ViewModels.User;

    public interface IAdminServices
    {
        Task<IList<ClassesInputViewModel>> GetClasses();

        Task<ClassesInputViewModel> GetClassIdAsync(int? id);

        Task AddNewClassAsync(ClassesInputViewModel classes);

        Task EditClassAsync(ClassesInputViewModel classes);

        Task DeleteClassAsync(ClassesInputViewModel classes);

        Task<IList<UserInputViewModel>> GetAllUsers();

        Task<ApplicationUser> GetUser(string username);

        Task<IList<UserRoleInputViewModel>> GetUserRole();

        Task<IList<RoleInputViewModel>> GetRole();

        Task ChangeRole(string username);

        Task<IList<EmployeeInputViewModel>> GetEmployees();

        Task<EmployeeInputViewModel> GetEmployeeIdAsync(string id);

        Task AddNewEmployeeAsync(EmployeeInputViewModel classes);

        Task EditEmployeeAsync(EmployeeInputViewModel classes);

        Task DeleteEmployeeAsync(EmployeeInputViewModel classes);

        Task<IList<SubscriptionsInputViewModel>> GetSubscriptions();

        Task<SubscriptionsInputViewModel> GetSubscriptionIdAsync(int? id);

        Task AddNewSubscriptionAsync(SubscriptionsInputViewModel subscriptions);

        Task EditSubscriptionAsync(SubscriptionsInputViewModel subscriptions);

        Task DeleteSubscriptionAsync(SubscriptionsInputViewModel subscriptions);
    }
}
