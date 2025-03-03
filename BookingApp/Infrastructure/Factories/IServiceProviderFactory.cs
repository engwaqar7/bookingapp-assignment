using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure.Factories
{
    public interface IServiceProviderFactory
    {
        IServiceProvider GetServiceProvider(string providerType);
    }
}
