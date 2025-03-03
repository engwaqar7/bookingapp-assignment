using BookingApp.Models;
using Newtonsoft.Json.Linq;

namespace BookingApp.Infrastructure.Providers
{
    public class SabreServiceProvider(ApiClient apiClient) : IServiceProvider
    {
        private readonly ApiClient _apiClient = apiClient;

        public async Task<Flight[]> SearchFlightsAsync(string departure, string arrival, string departureDateTime)
        {
            string endpoint = $"flights?origin={departure}&destination={arrival}&departuredate={departureDateTime}";
            Console.WriteLine("\nSearching for flights using Sabre...");
            var response = await _apiClient.GetDataFromApiAsync(endpoint);

            // If the response is the dummy, skip the mapping
            if (response == "dummy_data")
            {
                return
                [
                    new Flight("Dummy Airline", "DA123", "2025-01-01 08:00", "2025-01-01 10:00", 199.99m),
                    new Flight("Dummy Airline", "DA456", "2025-01-01 12:00", "2025-01-01 14:00", 249.99m)
                ];
            }

            var flightData = JArray.Parse(response);
            return flightData.Select(ModelParser.ParseFlight).ToArray();
        }

        public async Task<Hotel[]> SearchHotelsAsync(string city)
        {
            string endpoint = $"hotels?city={city}";
            Console.WriteLine("\nSearching for hotels using Sabre...");
            var response = await _apiClient.GetDataFromApiAsync(endpoint);

            // If the response is the dummy, skip the mapping
            if (response == "dummy_data")
            {
                return
                [
                    new Hotel("Dummy Hotel", "123 Fake St, Fake City", "3 Star", 99.99m),
                    new Hotel("Dummy Hotel", "456 Imaginary Ave, Imaginary City", "4 Star", 149.99m)
                ];
            }

            var hotelData = JArray.Parse(response);
            return hotelData.Select(ModelParser.ParseHotel).ToArray();
        }
    }
}
