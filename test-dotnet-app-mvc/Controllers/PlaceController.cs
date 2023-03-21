using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test_dotnet_app_mvc.Controllers.Service;
using test_dotnet_app_mvc.Models;

namespace test_dotnet_app_mvc.Controllers
{
    public class PlaceController : Controller
    {
        private readonly MyDbContext _context;

        public PlaceController(MyDbContext context)
        {
            _context = context;


        }

        public IActionResult Index()
        {
            PlaceService us = new PlaceService(_context);
            var result = us.GetPlaces();

            var places = new List<Place>();
            foreach (var p in result.Result.Value)
            {
                Place place = new Place();
                place.ID = p.ID;
                place.NAME = p.NAME;
                place.DESCRIPTION = p.DESCRIPTION;
                place.IMAGEURL = p.IMAGEURL;
                places.Add(place);
            }
           
            return View(places);
        }
    }

}
