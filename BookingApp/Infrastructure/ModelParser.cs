using BookingApp.Models;
using Newtonsoft.Json.Linq;

namespace BookingApp.Infrastructure
{
    public static class ModelParser
    {
        // Parse a flight item into a Flight object
        public static Flight ParseFlight(JToken item)
        {
            return new Flight(
                item["airline"].ToString(),
                item["flight_number"].ToString(),
                item["departure_time"].ToString(),
                item["arrival_time"].ToString(),
                decimal.Parse(item["price"].ToString())
            );
        }

        // Parse a hotel item into a Hotel object
        public static Hotel ParseHotel(JToken item)
        {
            return new Hotel(
                item["name"].ToString(),
                item["address"].ToString(),
                item["rating"].ToString(),
                decimal.Parse(item["price_per_night"].ToString())
            );
        }
    }
}
