using MediatR;

namespace FlightSearch.Api.Application.Commands
{
    public record CreateFlightCommand(string FlightNumber, string DepartureAirport, string ArrivalAirport, DateTime DepartureTime, DateTime ArrivalTime, string Status) : IRequest<int>;
}
