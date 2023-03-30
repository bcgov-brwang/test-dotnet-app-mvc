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
    public class HotelService
    {

        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;


        public HotelService(MyDbContext context)
        {
            _context = context;
           

        }

        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotels()
        {

            try
            {
                var test = _context.Hotel.ToList();

            }
            catch (Exception exc)
            {
                string t = exc.Message;
                
            }


            var hotels = _context.Hotel.ToList();

            //var users = await _context.HET_USER.ToListAsync();
            var result = hotels;
            return result;
        }
    }

}
