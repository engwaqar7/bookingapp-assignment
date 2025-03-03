using BookingApp.Models;
using BookingApp.Services;

namespace BookingApp.Infrastructure.Factories
{
    public class SearchServiceFactory(IServiceProvider serviceProvider) : ISearchServiceFactory
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider;

        public ISearchService<T> GetSearchService<T>()
        {
            if (typeof(T) == typeof(Flight))
            {
                return (ISearchService<T>)new FlightSearchService(_serviceProvider);
            }
            else if (typeof(T) == typeof(Hotel))
            {
                return (ISearchService<T>)new HotelSearchService(_serviceProvider);
            }
            else
            {
                throw new Exception("Unknown search type.");
            }
        }
    }
}

