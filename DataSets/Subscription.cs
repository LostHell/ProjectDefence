using System;
using System.Collections.Generic;

namespace MODELS_PROJECT.Data
{
    public partial class Subscription
    {
        public Subscription()
        {
            UserSubscriptions = new HashSet<UserSubscriptions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int BenefitsId { get; set; }
        public decimal Price { get; set; }
        public int Discount { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }

        public virtual Benefits Benefits { get; set; }
        public virtual ICollection<UserSubscriptions> UserSubscriptions { get; set; }
    }
}
