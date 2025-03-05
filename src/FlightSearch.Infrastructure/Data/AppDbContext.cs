using FlightSearch.Infrastructure.Configurations;
using FlightSearch.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
namespace FlightSearch.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new AirportConfiguration());
        }
    }
}