using BookingApp.Models;

namespace BookingApp.Services
{
    public class FlightSearchService(Infrastructure.IServiceProvider serviceProvider) : ISearchService<Flight>
    {
        private readonly Infrastructure.IServiceProvider _serviceProvider = serviceProvider;

        public async Task SearchAsync()
        {
            Console.WriteLine("\nPlease enter the departure airport code (3-letter code, e.g., LHR):");
            string departure = Console.ReadLine();

            Console.WriteLine("Enter arrival airport code (3 letter code: e.g: DXB):");
            string arrival = Console.ReadLine();

            Console.WriteLine("Please enter the Departure Date (Format: yyyy-MM-dd, e.g., 2026-03-09):");
            string departureDateTime = Console.ReadLine();

            if (string.IsNullOrEmpty(departure) || string.IsNullOrEmpty(arrival) || string.IsNullOrEmpty(departureDateTime))
            {
                Console.WriteLine("\nAll required information is missing. Please provide the necessary details.");
            }

            // Call the provider to get the flight data
            var flights = await _serviceProvider.SearchFlightsAsync(departure, arrival, departureDateTime);

            if (flights == null || flights.Length == 0)
            {
                Console.WriteLine("\nNo flights found, returning dummy data.");

                // Return dummy data if no flights were found
                flights =
                [
                    new Flight("Dummy Airline", "DA123", "2025-01-01 08:00", "2025-01-01 10:00", 199.99m),
                    new Flight("Dummy Airline", "DA456", "2025-01-01 12:00", "2025-01-01 14:00", 249.99m)
                ];
            }

            // Display results in table.
            DisplayFlightsInTable(flights);
        }

        public void DisplayFlightsInTable(Flight[] flights)
        {
            if (flights == null || flights.Length == 0)
            {
                Console.WriteLine("No flights to display.");
                return;
            }

            Console.WriteLine("| Airline        | Flight Number | Departure        | Arrival          | Price  |");
            Console.WriteLine("|----------------|---------------|------------------|------------------|--------|");

            foreach (var flight in flights)
            {
                Console.WriteLine($"| {flight.Airline,-14} | {flight.FlightNumber,-13} | {flight.DepartureTime,-16} | {flight.ArrivalTime,-16} | {flight.Price:C} |");
            }
        }
    }
}
