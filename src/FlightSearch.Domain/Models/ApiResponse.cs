using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSearch.Domain.Models
{
    public class ApiResponse<T>
    {
        public IEnumerable<T> Data { get; set; }
    }
}
