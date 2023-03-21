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
    public class PlaceService
    {

        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;


        public PlaceService(MyDbContext context)
        {
            _context = context;
           

        }

        public async Task<ActionResult<IEnumerable<Place>>> GetPlaces()
        {

            try
            {
                var test = _context.Place.ToList();

            }
            catch (Exception exc)
            {
                string t = exc.Message;
                
            }


            var places = _context.Place.ToList();

            //var users = await _context.HET_USER.ToListAsync();
            var result = places;
            return result;
        }
    }

}
