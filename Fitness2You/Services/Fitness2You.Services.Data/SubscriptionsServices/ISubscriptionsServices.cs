namespace Fitness2You.Services.Data.SubscriptionsServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Web.ViewModels.Subscription;

    public interface ISubscriptionsServices
    {
        Task<IList<SubscriptionsInputViewModel>> GetAll();

        Task AddNewSubscriptionAsync(SubscriptionsInputViewModel subscriptions);

        Task<SubscriptionsInputViewModel> GetIdAsync(int? id);

        Task EditAsync(SubscriptionsInputViewModel subscriptions);

        Task DeleteAsync(SubscriptionsInputViewModel subscriptions);
    }
}
