using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Infrastructure.Providers;

namespace BookingApp.Infrastructure.Factories
{
    public class ServiceProviderFactory : IServiceProviderFactory
    {
        private readonly ApiClient _apiClient;

        public ServiceProviderFactory(ApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IServiceProvider GetServiceProvider(string providerType)
        {
            if (providerType == "Sabre")
            {
                return new SabreServiceProvider(_apiClient);
            }
            else if (providerType == "Amadeus")
            {
                return new AmadeusServiceProvider(_apiClient);
            }
            else
            {
                throw new Exception("Unknown service provider.");
            }
        }
    }
}