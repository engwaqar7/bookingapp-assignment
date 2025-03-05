
using FlightSearch.Infrastructure.Entities;

namespace FlightSearch.Infrastructure.Repositories
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetFlightsAsync(string? departure, string? arrival, int page, int pageSize);
        Task AddFlightAsync(Flight flight);
    }
}
