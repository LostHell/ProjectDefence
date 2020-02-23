using Fitness2You.Models.Enums;
using System;
using System.Collections.Generic;

namespace MODELS_PROJECT.Data
{
    public partial class User
    {
        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            UserClasses = new HashSet<UserClass>();
            UserSubscriptions = new HashSet<UserSubscription>();
        }

        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public DateTime Date { get; set; }
        public Role Role { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<UserClass> UserClasses { get; set; }
        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; }
    }
}
