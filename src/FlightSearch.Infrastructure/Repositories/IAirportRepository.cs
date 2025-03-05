using FlightSearch.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearch.Infrastructure.Repositories
{
    public interface IAirportRepository
    {
        Task<IEnumerable<Airport>> GetAirportsAsync(int page, int pageSize);
        Task AddAirportAsync(Airport airport);
    }
}
