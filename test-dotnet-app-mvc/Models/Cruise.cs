using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_dotnet_app_mvc.Models
{
    public class Cruise
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string DESCRIPTION { get; set; }
        public string IMAGEURL { get; set; }

        public int PRICE { get; set; }
    }
}
