using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_dotnet_app_mvc.Controllers.Service;
using test_dotnet_app_mvc.Models;
using System.Linq;

namespace test_dotnet_app_mvc.Controllers
{
    public class AdminController : Controller
    {
        private readonly MyDbContext _dbContext;

        public AdminController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: Admin/Create
        public IActionResult CreateHotel()
        {
            return View();
        }

        public IActionResult CreateFlight()
        {
            return View();
        }

        public IActionResult CreateCruise()
        {
            return View();
        }

        public IActionResult CreateUser()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateHotel([FromForm] Hotel hotel)
        {

            HotelService hs = new HotelService(_dbContext);
            int maxId = hs.GetHotels().Result.Value.ToList().Select(x => x.ID).OrderByDescending(x => x).FirstOrDefault();

            if (ModelState.IsValid)
            {
                Hotel h = new Hotel();
                h.NAME = hotel.NAME;
                h.DESCRIPTION = hotel.DESCRIPTION;
                h.IMAGEURL = hotel.IMAGEURL;
                h.ID = maxId + 1;
                _dbContext.Hotel.Add(h);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Manage));
            }
            return View(hotel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFlight([Bind("Id,Name,Description")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(flight);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCruise([Bind("Id,Name,Description")] Cruise cruise)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Add(cruise);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cruise);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser([Bind("USER_ID,USER_DESCRIPTION")] User user)
        {
            if (ModelState.IsValid)
            {
                user.USER_ID = _dbContext.User.Select(x => x.USER_ID).OrderByDescending(x => x).FirstOrDefault() + 1;
                _dbContext.Add(user);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Manage));
            }
            return View(user);
        }

        public IActionResult Manage()
        {


            AllInfo allInfor = new AllInfo();

            HotelService hs = new HotelService(_dbContext);
            var resultHotels = hs.GetHotels();

            var hotels = new List<Hotel>();
            foreach (var h in resultHotels.Result.Value)
            {
                Hotel hotel = new Hotel();
                hotel.ID = h.ID;
                hotel.NAME = h.NAME;
                hotel.DESCRIPTION = h.DESCRIPTION;
                hotel.IMAGEURL = h.IMAGEURL;
                //hotel.PRICE = p.PRICE;
                hotels.Add(hotel);
            }

            FlightService fs = new FlightService(_dbContext);
            var resultFlights = fs.GetFlights();

            var flights = new List<Flight>();
            foreach (var f in resultFlights.Result.Value)
            {
                Flight flight = new Flight();
                flight.ID = f.ID;
                flight.NAME = f.NAME;
                flight.DESCRIPTION = f.DESCRIPTION;
                flight.IMAGEURL = f.IMAGEURL;
                //hotel.PRICE = p.PRICE;
                flights.Add(flight);
            }

            CruiseService cs = new CruiseService(_dbContext);
            var resultCruises = cs.GetCruises();

            var cruises = new List<Cruise>();
            foreach (var c in resultCruises.Result.Value)
            {
                Cruise cruise = new Cruise();
                cruise.ID = c.ID;
                cruise.NAME = c.NAME;
                cruise.DESCRIPTION = c.DESCRIPTION;
                cruise.IMAGEURL = c.IMAGEURL;
                //hotel.PRICE = p.PRICE;
                cruises.Add(cruise);
            }

            UserService us = new UserService(_dbContext);
            var resultUsers = us.GetUsers();

            var users = new List<User>();
            foreach (var c in resultUsers.Result.Value)
            {
                User user = new User();
                user.USER_ID = c.USER_ID;
                user.USER_DESCRIPTION = user.USER_DESCRIPTION;
                
                users.Add(user);
            }

            allInfor.Hotels = hotels;
            allInfor.Flights = flights;
            allInfor.Cruises = cruises;
            allInfor.Users = users;
            return View(allInfor);
            
        }
    }

}
