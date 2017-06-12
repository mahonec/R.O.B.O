using Robo.Models;
using Microsoft.EntityFrameworkCore;

namespace Robo.Util
{

    public class RoboContext : DbContext
    {
        protected override void OnConfiguring
      (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Startup.Configuration
               ["Data:DefaultConnection:ConnectionString"]);
        }

        public DbSet<Robo.Models.Robo> Robo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Robo.Models.Robo>().ToTable("Robo");
        }
    }
}