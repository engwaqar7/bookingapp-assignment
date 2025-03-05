using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightSearch.Domain.Models
{
    public class AviationStackAirportResponse
    {
        [JsonPropertyName("data")]
        public List<AviationStackAirportData> Data { get; set; }
    }
}
