using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace test_dotnet_app_mvc.Models
{
    public class Helpers
    {
        public IConfiguration Configuration { get; }

        public Helpers(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public string GetRDSConnectionString()
        {

            //var appConfig = ConfigurationManager.AppSettings;
            
            string dbname = Configuration["RDS_DB_NAME"];

            //if (string.IsNullOrEmpty(dbname)) return null;

            string username = Configuration["RDS_USERNAME"];
            string password = Configuration["RDS_PASSWORD"];
            string hostname = Configuration["RDS_HOSTNAME"];
            string port = Configuration["RDS_PORT"];


            //dbname = Configuration["RDS_DB_NAME"];
            //username = "postgres";
            //password = "Ywfwyfywxwyx_10";
            //port = "5432";
            //hostname = "database-1.c55myzbpex7n.us-east-1.rds.amazonaws.com";

            //return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
            return "Host=" + hostname + ";Database=" + dbname + ";Username=" + username + ";Password=" + password + ";" + ";Port=" + port + ";";
        }
    }
}
