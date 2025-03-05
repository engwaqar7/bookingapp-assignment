using FlightSearch.Infrastructure.Data;
using FlightSearch.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlightSearch.Infrastructure.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly AppDbContext _context;
        public FlightRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Flight>> GetFlightsAsync(string? departure, string? arrival, int page, int pageSize)
        {
            var query = _context.Flights.AsQueryable();
            if (!string.IsNullOrEmpty(departure))
                query = query.Where(f => f.DepartureAirport == departure);
            if (!string.IsNullOrEmpty(arrival))
                query = query.Where(f => f.ArrivalAirport == arrival);
            return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }


        public async Task AddFlightAsync(Flight flight)
        {
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();
        }
    }
}
