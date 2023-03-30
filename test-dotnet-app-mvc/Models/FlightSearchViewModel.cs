using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_dotnet_app_mvc.Models
{
    public class FlightSearchViewModel
    {
 
        public int Id { get; set; }
        public string FlightNumber { get; set; }

        public string Destination { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public string SearchTerm { get; set; }

        public List<Flight> Flights { get; set; }

    }

}
