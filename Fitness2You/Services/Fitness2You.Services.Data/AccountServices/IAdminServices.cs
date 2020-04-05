namespace Fitness2You.Services.Data.AccountServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Web.ViewModels.Class;
    using Fitness2You.Web.ViewModels.Subscription;
    using Fitness2You.Web.ViewModels.Trainer;
    using Fitness2You.Web.ViewModels.User;

    public interface IAdminServices
    {
        Task<IList<SubscriptionsInputViewModel>> GetSubscriptions();

        Task<IList<ClassesViewModel>> GetClasses();

        Task<IList<AllUserViewModel>> GetAllUsers();

        Task<IList<EmployeeViewModel>> GetEmployees();

        Task<SubscriptionsInputViewModel> GetIdAsync(int? id);

        Task AddNewSubscriptionAsync(SubscriptionsInputViewModel subscriptions);

        Task EditAsync(SubscriptionsInputViewModel subscriptions);

        Task DeleteAsync(SubscriptionsInputViewModel subscriptions);
    }
}
