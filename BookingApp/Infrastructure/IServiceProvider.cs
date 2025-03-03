using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Infrastructure
{
    public interface IServiceProvider
    {
        Task<Flight[]> SearchFlightsAsync(string departure, string arrival, string departureDateTime);
        Task<Hotel[]> SearchHotelsAsync(string city);
    }
}
