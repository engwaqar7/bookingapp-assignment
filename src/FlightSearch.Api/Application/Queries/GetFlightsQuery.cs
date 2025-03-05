using FlightSearch.Infrastructure.Entities;
using MediatR;

namespace FlightSearch.Api.Application.Queries
{
    public record GetFlightsQuery(string? DepartureAirport, string? ArrivalAirport, int Page, int PageSize) : IRequest<IEnumerable<Flight>>;
}
