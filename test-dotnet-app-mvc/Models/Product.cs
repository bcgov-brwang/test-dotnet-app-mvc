using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test_dotnet_app_mvc.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string NAME { get; set; }
        public string TYPE { get; set; }
        public int ORDER { get; set; }

        public string AREA { get; set; }
        public string COUNTRY { get; set; }
        public int GROUP_NUMBER { get; set; }
        public int DAYS { get; set; }
        public int NIGHTS { get; set; }
        public string DEPARTURE { get; set; }
        public string IMAGEURLS { get; set; }
        public string REASON { get; set; }
        public string DESCRIPTION { get; set; }
        public string TRANSPORTATION { get; set; }
        public string HOTEL { get; set; }
        public string MEALS { get; set; }
        public string ATTRACTIONS { get; set; }
        public string GROUP_DATE { get; set; }
        public string BOOK_BY_DATE { get; set; }
        public int ADULT_PRICE { get; set; }
        public int CHILD_PRICE { get; set; }
        public int SENIOR_PRICE { get; set; }
        public string PRICE_INCLUSIVE { get; set; }
        public string PRICE_EXCLUSIVE { get; set; }
        public string REFUND_CHANGE_DESCRIPTION { get; set; }
        public string REMARK { get; set; }
        public string LEAVE_GROUP_CITY { get; set; }

        public int PRODUCT_TYPE { get; set; }
        public bool IS_ON_HOMEPAGE { get; set; }
        public bool IS_RECOMMENDED { get; set; }



        //public int PRICE { get; set; }
    }
}
