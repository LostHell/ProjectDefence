using Fitness2You.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(200)]
        public string Email { get; set; }

        [Required]
        [MaxLength(200)]
        public string Password { get; set; }

        [Required]
        [MaxLength(200)]
        public string Salt { get; set; }

        public DateTime Date { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<UserClass> UserClasses { get; set; }
        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; }
    }
}
