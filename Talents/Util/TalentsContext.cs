using Talents.Models;
using Microsoft.EntityFrameworkCore;

namespace Talents.Util
{

    public class TalentsContext : DbContext
    {
        protected override void OnConfiguring
      (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Startup.Configuration
               ["Data:DefaultConnection:ConnectionString"]);
        }

        public DbSet<People> People { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Province> Province { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<People>().ToTable("People");
            modelBuilder.Entity<City>().ToTable("City");
            modelBuilder.Entity<Province>().ToTable("Province");
            modelBuilder.Entity<Country>().ToTable("Country");
        }
    }
}