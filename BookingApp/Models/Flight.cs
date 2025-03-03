namespace BookingApp.Models
{
    public class Flight(string airline, string flightNumber, string departureTime, string arrivalTime, decimal price)
    {
        public string Airline { get; set; } = airline;
        public string FlightNumber { get; set; } = flightNumber;
        public string DepartureTime { get; set; } = departureTime;
        public string ArrivalTime { get; set; } = arrivalTime;
        public decimal Price { get; set; } = price;
    }
}
