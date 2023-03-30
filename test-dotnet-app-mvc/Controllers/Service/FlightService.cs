using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using test_dotnet_app_mvc.Models;

namespace test_dotnet_app_mvc.Controllers.Service
{
    public class FlightService
    {

        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;


        public FlightService(MyDbContext context)
        {
            _context = context;
           

        }

        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        {

            try
            {
                var test = _context.Flight.ToList();

            }
            catch (Exception exc)
            {
                string t = exc.Message;
                
            }


            var flights = _context.Flight.ToList();

            //var users = await _context.HET_USER.ToListAsync();
            var result = flights;
            return result;
        }
    }

}
