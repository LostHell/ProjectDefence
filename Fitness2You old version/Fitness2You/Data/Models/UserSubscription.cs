namespace MODELS_PROJECT.Data
{
    public partial class UserSubscription
    {
        public UserSubscription()
        {
        }

        public int Id { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int SubscriptionId { get; set; }
        public virtual Subscription Subscription { get; set; }
    }
}
