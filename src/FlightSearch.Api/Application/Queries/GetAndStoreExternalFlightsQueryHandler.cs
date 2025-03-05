using FlightSearch.Domain.Models;
using FlightSearch.Domain.Services;
using FlightSearch.Infrastructure.Repositories;
using MediatR;

namespace FlightSearch.Api.Application.Queries
{
    public class GetAndStoreExternalFlightsQueryHandler : IRequestHandler<GetAndStoreExternalFlightsQuery, IEnumerable<Flight>>
    {
        private readonly IAviationStackService _aviationStackService;
        private readonly IFlightRepository _flightRepository;

        public GetAndStoreExternalFlightsQueryHandler(IAviationStackService aviationStackService, IFlightRepository flightRepository)
        {
            _aviationStackService = aviationStackService;
            _flightRepository = flightRepository;
        }

        public async Task<IEnumerable<Flight>> Handle(GetAndStoreExternalFlightsQuery request, CancellationToken cancellationToken)
        {
            var flights = await _aviationStackService.GetFlightsAsync(request.DepartureAirport, request.ArrivalAirport);

            foreach (var flight in flights)
            {
                var flightEntity = new FlightSearch.Infrastructure.Entities.Flight
                {
                    FlightNumber = flight.FlightNumber,
                    DepartureAirport = flight.DepartureAirport,
                    ArrivalAirport = flight.ArrivalAirport,
                    DepartureTime = flight.DepartureTime,
                    ArrivalTime = flight.ArrivalTime,
                    Status = flight.Status
                };
                await _flightRepository.AddFlightAsync(flightEntity);
            }

            return flights;
        }
    }

}
