using FlightSearch.Domain.Models;
using FlightSearch.Domain.Services;
using FlightSearch.Infrastructure.Repositories;
using MediatR;

namespace FlightSearch.Api.Application.Queries
{
    public class GetAndStoreExternalAirportsQueryHandler(IAviationStackService aviationStackService, IAirportRepository airportRepository) : IRequestHandler<GetAndStoreExternalAirportsQuery, IEnumerable<Airport>>
    {
        private readonly IAviationStackService _aviationStackService = aviationStackService;
        private readonly IAirportRepository _airportRepository = airportRepository;

        public async Task<IEnumerable<Airport>> Handle(GetAndStoreExternalAirportsQuery request, CancellationToken cancellationToken)
        {
            var airports = await _aviationStackService.GetAirportsAsync(request.SearchTerm);

            foreach (var airport in airports.Where(x => x.Country != null))
            {
                var airportEntity = new FlightSearch.Infrastructure.Entities.Airport
                {
                    Name = airport.Name,
                    Code = airport.Code,
                    City = airport.City,
                    Country = airport.Country,
                    Latitude = airport.Latitude,
                    Longitude = airport.Longitude
                };
                await _airportRepository.AddAirportAsync(airportEntity);
            }

            return airports;
        }
    }
}
