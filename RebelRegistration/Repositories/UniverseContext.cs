using Microsoft.EntityFrameworkCore;
using RebelRegistration.Models;

namespace RebelRegistration.Repositories
{
    public class UniverseContext : DbContext
    {
        //private readonly string _connectionString;
        public UniverseContext(DbContextOptions options) : base(options)
        {
            var optionss = options;
        }

        public DbSet<Planet> Planets { get; set; }
        public DbSet<PlanetLog> PlanetLogs { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    Database.SetInitializer<UniverseContext>(null);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlanetLog>()
                .HasOne(p => p.Planet)
                .WithMany(b => b.logs)
                .HasForeignKey(p => p.PlanetId)
                .HasPrincipalKey(b => b.PlanetId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=universe;User Id=postgres;Password=nada123;");
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Host=localhost;Database=universe;Username=postgres;Password=Nada123");


    }
}
