namespace Fitness2You.Web.ViewModels.Account
{
    using System;

    using Fitness2You.Data.Models;
    using Fitness2You.Services.Mapping;

    public class UserSubscriptionInputViewModel : IMapFrom<UserSubscription>
    {
        public DateTime TakeOn { get; set; }

        public Subscription Subscription { get; set; }

        public ApplicationUser User { get; set; }
    }
}
