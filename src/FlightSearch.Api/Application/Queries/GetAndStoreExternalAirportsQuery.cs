using FlightSearch.Domain.Models;
using MediatR;

namespace FlightSearch.Api.Application.Queries
{
    public record GetAndStoreExternalAirportsQuery(string? SearchTerm) : IRequest<IEnumerable<Airport>>;
}
