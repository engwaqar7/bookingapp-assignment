using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Services;

namespace BookingApp.Infrastructure.Factories
{
    public interface ISearchServiceFactory
    {
        ISearchService<T> GetSearchService<T>();
    }
}
