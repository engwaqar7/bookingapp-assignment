using FlightSearch.Infrastructure.Entities;
using FlightSearch.Infrastructure.Repositories;
using MediatR;

namespace FlightSearch.Api.Application.Commands
{
    public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, int>
    {
        private readonly IFlightRepository _flightRepository;
        public CreateFlightCommandHandler(IFlightRepository flightRepository) => _flightRepository = flightRepository;
        public async Task<int> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = new Flight
            {
                FlightNumber = request.FlightNumber,
                DepartureAirport = request.DepartureAirport,
                ArrivalAirport = request.ArrivalAirport,
                DepartureTime = request.DepartureTime,
                ArrivalTime = request.ArrivalTime,
                Status = request.Status
            };
            await _flightRepository.AddFlightAsync(flight);
            return flight.Id;
        }
    }
}
