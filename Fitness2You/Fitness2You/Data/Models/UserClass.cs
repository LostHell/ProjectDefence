namespace MODELS_PROJECT.Data
{
    public partial class UserClass
    {
        public UserClass()
        {
        }

        public int Id { get; set; }

        public string UserId { get; set; }
        public virtual User User { get; set; }

        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}
