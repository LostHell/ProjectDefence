using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MODELS_PROJECT.Data;

namespace Fitness2You.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Benefit> Benefits { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserClass> UserClasses { get; set; }
        public virtual DbSet<UserSubscription> UserSubscriptions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserClass>(entity =>
            {
                entity.HasOne(d => d.Class)
                    .WithMany(p => p.UserClasses)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClasses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserSubscription>(entity =>
            {
                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.UserSubscriptions)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSubscriptions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
