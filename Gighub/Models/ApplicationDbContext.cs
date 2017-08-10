﻿using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Gighub.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GIg> Gigs { get; set; }
        public DbSet<Following> Following { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            

            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Gig)
                .WithMany().
                WillCascadeOnDelete(false);
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.follower)
                .WithRequired(u => u.Followee)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(a => a.followee)
                .WithRequired(a => a.Follower)
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}