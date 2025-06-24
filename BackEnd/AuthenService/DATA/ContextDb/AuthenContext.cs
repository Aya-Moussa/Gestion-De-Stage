using DOMAIN.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
        public DbSet<Encadrant> encadrants{ get; set; }

    }
}
