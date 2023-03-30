using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_dotnet_app_mvc.Models
{
    public class Flight
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string IMAGEURL { get; set; }

        public string FlightNumber { get; set; }

        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        

        public int Price { get; set; }
        public string Destination { get; set; }

    }
}
