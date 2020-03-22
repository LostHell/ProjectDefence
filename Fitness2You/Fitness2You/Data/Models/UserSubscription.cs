using System.ComponentModel.DataAnnotations;

namespace Fitness2You.Data.Models
{
    public partial class UserSubscription
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public int SubscriptionId { get; set; }

        public virtual Subscription Subscription { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
