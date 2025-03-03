using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models
{
    public class Hotel(string name, string address, string rating, decimal pricePerNight)
    {
        public string Name { get; set; } = name;
        public string Address { get; set; } = address;
        public string Rating { get; set; } = rating;
        public decimal PricePerNight { get; set; } = pricePerNight;
    }
}
