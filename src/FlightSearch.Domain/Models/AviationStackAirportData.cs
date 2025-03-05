using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightSearch.Domain.Models
{
    public class AviationStackAirportData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("gmt")]
        public string Gmt { get; set; }

        [JsonPropertyName("airport_id")]
        public string AirportId { get; set; }

        [JsonPropertyName("iata_code")]
        public string IataCode { get; set; }

        [JsonPropertyName("city_iata_code")]
        public string CityIataCode { get; set; }

        [JsonPropertyName("icao_code")]
        public string IcaoCode { get; set; }

        [JsonPropertyName("country_iso2")]
        public string CountryIso2 { get; set; }

        [JsonPropertyName("geoname_id")]
        public string GeonameId { get; set; }

        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }

        [JsonPropertyName("airport_name")]
        public string AirportName { get; set; }

        [JsonPropertyName("country_name")]
        public string CountryName { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }
    }
}
