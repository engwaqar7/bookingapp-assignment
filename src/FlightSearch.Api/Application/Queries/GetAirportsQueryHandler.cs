using FlightSearch.Domain.Models;
using FlightSearch.Infrastructure.Repositories;
using MediatR;

namespace FlightSearch.Api.Application.Queries
{
    public class GetAirportsQueryHandler : IRequestHandler<GetAirportsQuery, IEnumerable<Airport>>
    {
        private readonly IAirportRepository _airportRepository;
        public GetAirportsQueryHandler(IAirportRepository airportRepository) => _airportRepository = airportRepository;
        public async Task<IEnumerable<Airport>> Handle(GetAirportsQuery request, CancellationToken cancellationToken)
        {
            var airportEntities = await _airportRepository.GetAirportsAsync(request.Page, request.PageSize);
            return airportEntities.Select(ae => new Airport
            {
                Id = ae.Id,
                Name = ae.Name,
                Code = ae.Code,
                City = ae.City,
                Country = ae.Country
            });
        }
    }
}
