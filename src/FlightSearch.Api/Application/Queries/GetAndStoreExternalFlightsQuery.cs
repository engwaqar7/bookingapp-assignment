using FlightSearch.Domain.Models;
using MediatR;

namespace FlightSearch.Api.Application.Queries
{
    public record GetAndStoreExternalFlightsQuery(string DepartureAirport, string ArrivalAirport) : IRequest<IEnumerable<Flight>>;
}
