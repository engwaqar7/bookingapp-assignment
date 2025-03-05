using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FlightSearch.Domain.Models
{
    public class AviationStackFlightResponse
    {
        [JsonPropertyName("data")]
        public List<AviationStackFlightData> Data { get; set; }
    }
}
