namespace Fitness2You.Services.Data.SubscriptionsServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Web.ViewModels.Subscription;

    public interface ISubscriptionsServices
    {
        Task<IList<SubscriptionsInputViewModel>> GetAll();

        Task AddUserToSubscription(int id, string username);
    }
}
