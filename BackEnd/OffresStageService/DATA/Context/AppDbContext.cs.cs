using DOMAIN.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tache> Taches { get; set; }
        public DbSet<OffreDeStage> Offres { get; set; }
        public DbSet<Candidature> Candidatures { get; set; }
        public DbSet<Stage> Stages { get; set; }
        public DbSet<JournalDeBord> Journaux { get; set; }
        public DbSet<CommentaireEncadrant> Commentaires { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<Entretien> Entretiens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Stage ↔ Evaluation (One-to-One)
            modelBuilder.Entity<Stage>()
                .HasOne(s => s.Evaluation)
                .WithOne(e => e.Stage)
                .HasForeignKey<Evaluation>(e => e.StageId)
                .OnDelete(DeleteBehavior.Cascade);

            // Stage ↔ Tache (One-to-Many)
            modelBuilder.Entity<Tache>()
                .HasOne(t => t.Stage)
                .WithMany(s => s.Taches)
                .HasForeignKey(t => t.StageId)
                .OnDelete(DeleteBehavior.Cascade);

            // Offre ↔ Candidature (One-to-Many)
            modelBuilder.Entity<Candidature>()
                .HasOne(c => c.Offre)
                .WithMany(o => o.Candidatures)
                .HasForeignKey(c => c.OffreId)
                .OnDelete(DeleteBehavior.Cascade);

            // Offre ↔ Stage (One-to-Many)
            modelBuilder.Entity<Stage>()
                .HasOne(s => s.Offre)
                .WithMany(o => o.Stages)
                .HasForeignKey(s => s.OffreId)
                .OnDelete(DeleteBehavior.Cascade);

            // Journal ↔ CommentaireEncadrant (One-to-Many)
            modelBuilder.Entity<CommentaireEncadrant>()
                .HasOne(c => c.Journal)
                .WithMany(j => j.Commentaires)
                .HasForeignKey(c => c.JournalId)
                .OnDelete(DeleteBehavior.Cascade);

            // Stage ↔ Entretien (One-to-Many)
            modelBuilder.Entity<Entretien>()
                .HasOne(e => e.Stage)
                .WithMany()
                .HasForeignKey(e => e.StageId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
