namespace Fitness2You.Web.ViewModels.Account
{
    using System.Collections.Generic;

    public class MyAccountInputViewModel
    {
        public IList<UserSubscriptionInputViewModel> UserSubscription { get; set; }

        public IList<UserClassInputViewModel> UserClass { get; set; }
    }
}
