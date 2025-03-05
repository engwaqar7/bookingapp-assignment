using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightSearch.Domain.Models
{
    public class AviationStackFlightData
    {
        [JsonPropertyName("flight_date")]
        public string FlightDate { get; set; }

        [JsonPropertyName("flight_status")]
        public string FlightStatus { get; set; }

        [JsonPropertyName("departure")]
        public FlightDeparture Departure { get; set; }

        [JsonPropertyName("arrival")]
        public FlightArrival Arrival { get; set; }

        [JsonPropertyName("airline")]
        public AirlineInfo Airline { get; set; }

        [JsonPropertyName("flight")]
        public FlightInfo Flight { get; set; }

        [JsonPropertyName("aircraft")]
        public AircraftInfo Aircraft { get; set; }

        [JsonPropertyName("live")]
        public LiveFlightInfo Live { get; set; }
    }

    public class FlightDeparture
    {
        [JsonPropertyName("airport")]
        public string Airport { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("iata")]
        public string Iata { get; set; }

        [JsonPropertyName("icao")]
        public string Icao { get; set; }

        [JsonPropertyName("terminal")]
        public string Terminal { get; set; }

        [JsonPropertyName("gate")]
        public string Gate { get; set; }

        [JsonPropertyName("delay")]
        public int? Delay { get; set; }

        [JsonPropertyName("scheduled")]
        public DateTime Scheduled { get; set; }

        [JsonPropertyName("estimated")]
        public string Estimated { get; set; }

        [JsonPropertyName("actual")]
        public string Actual { get; set; }

        [JsonPropertyName("estimated_runway")]
        public string EstimatedRunway { get; set; }

        [JsonPropertyName("actual_runway")]
        public string ActualRunway { get; set; }
    }

    public class FlightArrival : FlightDeparture { }

    public class AirlineInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("iata")]
        public string Iata { get; set; }

        [JsonPropertyName("icao")]
        public string Icao { get; set; }
    }

    public class FlightInfo
    {
        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("iata")]
        public string Iata { get; set; }

        [JsonPropertyName("icao")]
        public string Icao { get; set; }
    }

    public class AircraftInfo
    {
        [JsonPropertyName("registration")]
        public string Registration { get; set; }

        [JsonPropertyName("iata")]
        public string Iata { get; set; }

        [JsonPropertyName("icao")]
        public string Icao { get; set; }

        [JsonPropertyName("icao24")]
        public string Icao24 { get; set; }
    }

    public class LiveFlightInfo
    {
        [JsonPropertyName("updated")]
        public string Updated { get; set; }

        [JsonPropertyName("latitude")]
        public double? Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double? Longitude { get; set; }

        [JsonPropertyName("altitude")]
        public double? Altitude { get; set; }

        [JsonPropertyName("direction")]
        public double? Direction { get; set; }

        [JsonPropertyName("speed_horizontal")]
        public double? SpeedHorizontal { get; set; }

        [JsonPropertyName("speed_vertical")]
        public double? SpeedVertical { get; set; }

        [JsonPropertyName("is_ground")]
        public bool IsGround { get; set; }
    }
}
