using Acadon.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Acadon.Data
{
    public class ApplicationDbContext : IdentityDbContext<Korisnik>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Razred> Razred { get; set; }

        public DbSet<Predmet> Predmet { get; set; }

        public DbSet<RazredPredmet> RazredPredmet { get; set; }

        public DbSet<Cas> Cas { get; set; }

        public DbSet<Izostanak> Izostanak { get; set; }

        public DbSet<Ocjena> Ocjena { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Razred>().ToTable("Razred");

            modelBuilder.Entity<Predmet>().ToTable("Predmet");

            modelBuilder.Entity<RazredPredmet>().ToTable("RazredPredmet");

            modelBuilder.Entity<Cas>().ToTable("Cas");

            modelBuilder.Entity<Izostanak>().ToTable("Izostanak");

            modelBuilder.Entity<Ocjena>().ToTable("Ocjena");

            modelBuilder.Entity<Korisnik>(b =>
            {
                b.Property(u => u.Ime);
                b.Property(u => u.Prezime);
                b.Property(u => u.Vladanje);
                b.Property(u => u.RazredID);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
