using FlightSearch.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace FlightSearch.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.ToTable("Flights");
            builder.HasKey(f => f.Id);
            builder.Property(f => f.FlightNumber).IsRequired().HasMaxLength(50);
            builder.Property(f => f.Status).HasMaxLength(50);
        }
    }
}