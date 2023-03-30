using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_dotnet_app_mvc.Controllers.Service;
using test_dotnet_app_mvc.Models;

namespace test_dotnet_app_mvc.Controllers
{
    public class FlightController : Controller
    {
        private readonly MyDbContext _context;

        public FlightController(MyDbContext context)
        {
            _context = context;


        }
        public IActionResult Index()
        {
            FlightService cs = new FlightService(_context);
            var result = cs.GetFlights();

            var flights = new List<Flight>();
            foreach (var p in result.Result.Value)
            {
                Flight flight = new Flight();
                flight.ID = p.ID;
                flight.NAME = p.NAME;
                flight.DESCRIPTION = p.DESCRIPTION;
                flight.IMAGEURL = p.IMAGEURL;
                //flight.PRICE = p.PRICE;
                flights.Add(flight);
            }

            return View(flights);
        }

        [HttpGet]
        public IActionResult Search(string searchText)
        {
            // Search for flights based on the search text
            if (searchText == null)
            {
                return View();
            }
            else
            {
                //var flights = _context.Flight.Where(f => f.FlightNumber.Contains(searchText)
                //                                  || f.Departure.Contains(searchText)
                //                                  || f.Arrival.Contains(searchText))
                //                          .ToList();

                List<Flight> flights = new List<Flight>();
                Flight f1 = new Flight();
                f1.DepartureTime = "2022-03-23:12:00:00";
                f1.ArrivalTime = "2022-03-24:12:00:00";
                f1.DESCRIPTION = "this is a test flight";
                f1.FlightNumber = "AC5840";
                f1.Destination = "HK";
                f1.NAME = "HK Flight";
                f1.Price = 1280;
                flights.Add(f1);

                //    List<Flight> flights = new List<Flight>() { f1 };

                return View(flights);

            }
            
        }

        //[HttpGet("{SearchTerm}")]
        //public IActionResult Search([FromQuery] string searchTerm)
        //{


        //    FlightSearchViewModel flightSearchViewModel = new FlightSearchViewModel();
        //    Flight f1 = new Flight();
        //    f1.DepartureTime = new DateTime(2022, 3, 23, 12, 00, 00);
        //    f1.ArrivalTime = new DateTime(2022, 3, 24, 12, 23, 50);
        //    f1.DESCRIPTION = "this is a test flight";
        //    f1.FlightNumber = "AC5840";
        //    f1.Destination = "HK";
        //    f1.NAME = "HK Flight";

        //    List<Flight> flights = new List<Flight>() { f1 };
        //    flightSearchViewModel.Flights = flights;
        //    return View(flightSearchViewModel);
        //}
    }
}
