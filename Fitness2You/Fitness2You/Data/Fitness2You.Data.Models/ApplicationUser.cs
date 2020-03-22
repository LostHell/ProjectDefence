// ReSharper disable VirtualMemberCallInConstructor
namespace Fitness2You.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Fitness2You.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;
    using MODELS_PROJECT.Data;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.UserClasses = new HashSet<UserClass>();
            this.UserSubscriptions = new HashSet<UserSubscription>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<UserClass> UserClasses { get; set; }

        public virtual ICollection<UserSubscription> UserSubscriptions { get; set; }
    }
}
