using System;
using System.Collections.Generic;

namespace MODELS_PROJECT.Data
{
    public partial class Users
    {
        public Users()
        {
            UserClasses = new HashSet<UserClasses>();
            UserSubscriptions = new HashSet<UserSubscriptions>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<UserClasses> UserClasses { get; set; }
        public virtual ICollection<UserSubscriptions> UserSubscriptions { get; set; }
    }
}
