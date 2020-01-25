using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MODELS_PROJECT.Data
{
    public partial class Fitness2YouContext : DbContext
    {
        public Fitness2YouContext()
        {
        }

        public Fitness2YouContext(DbContextOptions<Fitness2YouContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Benefits> Benefits { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Subscription> Subscription { get; set; }
        public virtual DbSet<UserClasses> UserClasses { get; set; }
        public virtual DbSet<UserSubscriptions> UserSubscriptions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-71JL2HP;Database=Fitness2You;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Benefits>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            });

            modelBuilder.Entity<Classes>(entity =>
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

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);
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

            modelBuilder.Entity<UserClasses>(entity =>
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

            modelBuilder.Entity<UserSubscriptions>(entity =>
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

            modelBuilder.Entity<Users>(entity =>
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
