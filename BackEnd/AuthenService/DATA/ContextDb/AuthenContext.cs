using DOMAIN.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace DATA.ContextDb
{
    public class AuthenContext : DbContext
    {
        public AuthenContext(DbContextOptions<AuthenContext> options)
            : base(options)
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<RH> RHs { get; set; }
        public DbSet<Stagiaire> stagiaires { get; set; }
        public DbSet<Encadrant> encadrants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Utilisateur>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}


