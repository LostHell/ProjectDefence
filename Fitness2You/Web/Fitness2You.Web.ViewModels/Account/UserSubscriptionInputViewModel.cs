namespace Fitness2You.Web.ViewModels.Account
{
    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;

    public class UserSubscriptionInputViewModel : IMapFrom<UserSubscription>
    {
        public Subscription Subscription { get; set; }

        public ApplicationUser User { get; set; }
    }
}
