using Microsoft.Extensions.Configuration;
using BookingApp.Models;
using BookingApp.Infrastructure.Factories;
using BookingApp.Infrastructure;

namespace BookingApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Load configuration from appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            Console.WriteLine("Welcome to the booking app - search hotels and flights.");

            // Ask the user to select a service provider
            Console.WriteLine("\nSelect Service Provider:");
            Console.WriteLine("1. Sabre");
            Console.WriteLine("2. Amadeus");
            Console.WriteLine("3. Exit");

            string choice = Console.ReadLine();

            if (choice == "3")
            {
                Console.WriteLine("Exiting the app. Goodbye!");
                return;
            }

            // Initialize ApiClient based on the selected provider
            string provider = choice switch
            {
                "1" => "Sabre",
                "2" => "Amadeus",
                _ => throw new Exception("Invalid choice.")
            };

            var apiClient = new ApiClient(config, provider);

            // Initialize theServiceProviderFactory
            var serviceProviderFactory = new ServiceProviderFactory(apiClient);

            // Get the selected service provider (Sabre or Amadeus)
            Infrastructure.IServiceProvider serviceProvider = serviceProviderFactory.GetServiceProvider(provider);

            // Initialize the SearchServiceFactory
            var searchServiceFactory = new SearchServiceFactory(serviceProvider);

            // Ask the user what they want to search for (flights or hotels)
            Console.WriteLine("\nSelect what you want to search for:");
            Console.WriteLine("1. Flights");
            Console.WriteLine("2. Hotels");
            string searchChoice = Console.ReadLine();

            // Select the correct type of search service (Flight or Hotel)
            if (searchChoice == "1")
            {
                var flightSearchService = searchServiceFactory.GetSearchService<Flight>();
                await flightSearchService.SearchAsync();
            }
            else if (searchChoice == "2")
            {
                var hotelSearchService = searchServiceFactory.GetSearchService<Hotel>();
                await hotelSearchService.SearchAsync();
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
    }
}
