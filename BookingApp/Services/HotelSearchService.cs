using BookingApp.Models;

namespace BookingApp.Services
{
    public class HotelSearchService(Infrastructure.IServiceProvider serviceProvider) : ISearchService<Hotel>
    {
        private readonly Infrastructure.IServiceProvider _serviceProvider = serviceProvider;

        public async Task SearchAsync()
        {
            Console.WriteLine("\nEnter the city for hotel search:");
            string city = Console.ReadLine();

            if (string.IsNullOrEmpty(city))
            {
                Console.WriteLine("\nPlease provide a city for the search.");
            }

            // Call the provider to get the hotel data
            var hotels = await _serviceProvider.SearchHotelsAsync(city);

            if (hotels == null || hotels.Length == 0)
            {
                Console.WriteLine("\nNo hotels found, returning dummy data.");

                // Return dummy data if no hotels were found
                hotels = new Hotel[]
                {
                    new Hotel("Dummy Hotel", "123 Fake St, Fake City", "3 Star", 99.99m),
                    new Hotel("Dummy Hotel", "456 Imaginary Ave, Imaginary City", "4 Star", 149.99m)
                };
            }

            // Display results in table.
            DisplayHotelsInTable(hotels);
        }

        public void DisplayHotelsInTable(Hotel[] hotels)
        {
            if (hotels == null || hotels.Length == 0)
            {
                Console.WriteLine("No hotels to display.");
                return;
            }

            Console.WriteLine("| Hotel Name          | Address                | Rating  | Price per Night |");
            Console.WriteLine("|---------------------|------------------------|---------|-----------------|");

            foreach (var hotel in hotels)
            {
                Console.WriteLine($"| {hotel.Name,-20} | {hotel.Address,-22} | {hotel.Rating,-7} | {hotel.PricePerNight:C}        |");
            }
        }
    }
}
