using FlightSearch.Domain.Models;
using MediatR;

namespace FlightSearch.Api.Application.Queries
{
    public record GetAirportsQuery(int Page, int PageSize) : IRequest<IEnumerable<Airport>>;
}
