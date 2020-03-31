namespace Fitness2You.Services.Data.AccountServices
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Fitness2You.Web.ViewModels.Subscription;

    public interface IAccountServices
    {
        Task<IList<SubscriptionsInputViewModel>> GetSubscriptions();
    }
}
