using FlightSearch.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace FlightSearch.Infrastructure.Configurations
{
    public class AirportConfiguration : IEntityTypeConfiguration<Airport>
    {
        public void Configure(EntityTypeBuilder<Airport> builder)
        {
            builder.ToTable("Airports");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Code).IsRequired().HasMaxLength(10);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
        }
    }
}