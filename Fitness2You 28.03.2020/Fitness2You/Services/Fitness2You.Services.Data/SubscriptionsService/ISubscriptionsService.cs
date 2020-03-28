namespace Fitness2You.Services.Data.SubscriptionsService
{
    using System.Threading.Tasks;

    using Fitness2You.Web.ViewModels.Subscriptions;

    public interface ISubscriptionsService
    {
        Task AddSubscription(InputSubscriptionsViewModel input);

        bool ExistName(string name);
    }
}
