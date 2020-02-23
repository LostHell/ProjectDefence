using System;
using System.Collections.Generic;

namespace MODELS_PROJECT.Data
{
    public partial class Subscription
    {
        public Subscription()
        {
            this.Id = Guid.NewGuid().ToString();
            UserSubscriptions = new HashSet<UserSubscription>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string BenefitsId { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual Benefit Benefits { get; set; }
        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; }
    }
}
