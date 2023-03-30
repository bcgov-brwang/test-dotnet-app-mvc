using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_dotnet_app_mvc.Models
{
    public class AllInfo
    {
        public List<Cruise> Cruises { get; set; }
        public List<Hotel> Hotels { get; set; }
        public List<Flight> Flights { get; set; }

        public List<User> Users { get; set; }
    }
}
