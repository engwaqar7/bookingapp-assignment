using FlightSearch.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearch.Domain.Services
{
    public interface IAviationStackService
    {
        Task<IEnumerable<Flight>> GetFlightsAsync(string departure, string arrival);

        Task<IEnumerable<Airport>> GetAirportsAsync(string? searchTerm);
    }
}
