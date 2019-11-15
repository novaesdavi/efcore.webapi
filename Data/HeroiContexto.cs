using EFCore.WebApi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.WebApi.Data
{
    public class HeroiContexto : DbContext
    {

        public DbSet<Arma> Armas { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Heroi> Herois { get; set; }

        public DbSet<IdentidadeSecreta> IdentidadeSecretas { get; set; }

        public DbSet<HeroiBatalha> HeroiBatalhas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=teste123;Persist Security Info=True;User ID=sa;Initial Catalog=HeroApp;Data Source=DESKTOP-OI3NRP1");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HeroiBatalha>(entity => {
                entity.HasKey(e => new { e.BatalhaId, e.HeroiId });
            });
        }
    }
}
