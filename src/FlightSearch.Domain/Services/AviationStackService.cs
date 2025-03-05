using FlightSearch.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FlightSearch.Domain.Services
{
    public class AviationStackService : IAviationStackService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public AviationStackService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["AviationStack:ApiKey"];
        }

        public async Task<IEnumerable<Flight>> GetFlightsAsync(string departure, string arrival)
        {
            var url = $"http://api.aviationstack.com/v1/flights?access_key={_apiKey}&dep_iata={departure}&arr_iata={arrival}";
            var response = await _httpClient.GetStringAsync(url);
            var jsonResponse = JsonSerializer.Deserialize<AviationStackFlightResponse>(response);
            return jsonResponse?.Data.Select(f => new Flight
            {
                FlightNumber = f.Flight.Number,
                DepartureAirport = f.Departure.Iata,
                ArrivalAirport = f.Arrival.Iata,
                DepartureTime = f.Departure.Scheduled,
                ArrivalTime = f.Arrival.Scheduled,
                Status = f.FlightStatus
            }) ?? [];
        }

        public async Task<IEnumerable<Airport>> GetAirportsAsync(string? searchTerm)
        {
            var url = $"http://api.aviationstack.com/v1/airports?access_key={_apiKey}";
            var response = await _httpClient.GetStringAsync(url);
            var jsonResponse = JsonSerializer.Deserialize<AviationStackAirportResponse>(response);
            return jsonResponse?.Data.Select(a => new Airport
            {
                Name = a.AirportName,
                Code = a.IataCode,
                City = a.CityIataCode,
                Country = a.CountryName,
                Latitude = Convert.ToDecimal(a.Latitude),
                Longitude = Convert.ToDecimal(a.Longitude)
            }) ?? new List<Airport>();
        }
    }
}
