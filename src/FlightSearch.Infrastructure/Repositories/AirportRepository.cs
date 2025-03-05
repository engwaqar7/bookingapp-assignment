using FlightSearch.Infrastructure.Data;
using FlightSearch.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightSearch.Infrastructure.Repositories
{
    public class AirportRepository : IAirportRepository
    {
        private readonly AppDbContext _context;
        public AirportRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Airport>> GetAirportsAsync(int page, int pageSize)
        {
            return await _context.Airports.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task AddAirportAsync(Airport airport)
        {
            _context.Airports.Add(airport);
            await _context.SaveChangesAsync();
        }
    }
}
