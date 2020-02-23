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
        public DbSet<Benefit> Benefits { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserClass> UserClasses { get; set; }
        public DbSet<UserSubscription> UserSubscriptions { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Benefit>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 0)");
            });

            modelBuilder.Entity<Subscription>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 0)");

                entity.HasOne(d => d.Benefits)
                    .WithMany(p => p.Subscription)
                    .HasForeignKey(d => d.BenefitsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subscript__Benef__3B75D760");
            });

            modelBuilder.Entity<UserClass>(entity =>
            {
                entity.HasOne(d => d.Class)
                    .WithMany(p => p.UserClasses)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserClass__Class__44FF419A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserClasses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserClass__UserI__440B1D61");
            });

            modelBuilder.Entity<UserSubscription>(entity =>
            {
                entity.HasOne(d => d.Subscription)
                    .WithMany(p => p.UserSubscriptions)
                    .HasForeignKey(d => d.SubscriptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserSubsc__Subsc__3F466844");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserSubscriptions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserSubsc__UserI__3E52440B");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });
        }
    }
}
