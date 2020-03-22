using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MODELS_PROJECT.Data
{
    public partial class Subscription
    {
        public Subscription()
        {
            UserSubscriptions = new HashSet<UserSubscription>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int BenefitsId { get; set; }
        public virtual Benefit Benefits { get; set; }

        [Range(0,1000000)]
        public decimal Price { get; set; }

        [Range(0,1000000)]
        public int Discount { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; }
    }
}
