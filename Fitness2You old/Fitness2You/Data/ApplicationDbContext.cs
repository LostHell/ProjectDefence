using Fitness2You.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fitness2You.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Benefit> Benefits { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }

        public DbSet<UserClass> UserClasses { get; set; }

        public DbSet<UserSubscription> UserSubscriptions { get; set; }
    }
}
