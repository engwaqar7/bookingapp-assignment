using FlightSearch.Infrastructure.Entities;
using FlightSearch.Infrastructure.Repositories;
using MediatR;

namespace FlightSearch.Api.Application.Queries
{
    public class GetFlightsQueryHandler : IRequestHandler<GetFlightsQuery, IEnumerable<Flight>>
    {
        private readonly IFlightRepository _flightRepository;
        public GetFlightsQueryHandler(IFlightRepository flightRepository) => _flightRepository = flightRepository;
        public async Task<IEnumerable<Flight>> Handle(GetFlightsQuery request, CancellationToken cancellationToken)
        {
            var flightEntities = await _flightRepository.GetFlightsAsync(request.DepartureAirport, request.ArrivalAirport, request.Page, request.PageSize);
            return flightEntities.Select(fe => new Flight
            {
                Id = fe.Id,
                FlightNumber = fe.FlightNumber,
                DepartureAirport = fe.DepartureAirport,
                ArrivalAirport = fe.ArrivalAirport,
                DepartureTime = fe.DepartureTime,
                ArrivalTime = fe.ArrivalTime,
                Status = fe.Status
            });
        }
    }
}
