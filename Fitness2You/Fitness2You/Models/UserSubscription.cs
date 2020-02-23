using System;
using System.Collections.Generic;

namespace MODELS_PROJECT.Data
{
    public partial class UserSubscription
    {
        public UserSubscription()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public string SubscriptionId { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
