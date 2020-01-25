using System;
using System.Collections.Generic;

namespace MODELS_PROJECT.Data
{
    public partial class UserSubscriptions
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SubscriptionId { get; set; }

        public virtual Subscription Subscription { get; set; }
        public virtual Users User { get; set; }
    }
}
