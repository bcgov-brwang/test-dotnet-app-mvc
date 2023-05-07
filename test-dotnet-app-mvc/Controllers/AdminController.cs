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

        public IActionResult CreatePlace()
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

        public IActionResult CreateProduct()
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
        public async Task<IActionResult> CreatePlace([FromForm] Place place)
        {

            
            int maxId = _dbContext.Place.ToList().Select(x => x.ID).OrderByDescending(x => x).FirstOrDefault();

            if (ModelState.IsValid)
            {
                Place h = new Place();
                h.NAME = place.NAME;
                h.DESCRIPTION = place.DESCRIPTION;
                h.IMAGEURL = place.IMAGEURL;
                h.ID = maxId + 1;
                _dbContext.Place.Add(h);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Manage));
            }
            return View(place);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFlight([Bind("NAME, DESCRIPTION, IMAGEURL")] Flight flight)
        {
            int id = 0;
            var existingFlight = _dbContext.Flight.OrderByDescending(x => x.ID).FirstOrDefault();
            if (existingFlight == null)
            {
                id = 1;
            }
            else
            {
                id = existingFlight.ID + 1;
            }
            if (ModelState.IsValid)
            {
                flight.ID = id;
                _dbContext.Add(flight);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flight);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCruise([Bind("NAME,DESCRIPTION, IMAGEURL")] Cruise cruise)
        {
            int id = 0;
            var existingCruise = _dbContext.Cruise.OrderByDescending(x => x.ID).FirstOrDefault();
            if (existingCruise == null)
            {
                id = 1;
            }
            else
            {
                id = existingCruise.ID + 1;
            }
            if (ModelState.IsValid)
            {
                cruise.ID = id;
                _dbContext.Add(cruise);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View("Manage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser([Bind("ID,DESCRIPTION")] User user)
        {
            if (ModelState.IsValid)
            {
                user.ID = _dbContext.User.Select(x => x.ID).OrderByDescending(x => x).FirstOrDefault() + 1;
                _dbContext.Add(user);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Manage));
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct([FromForm] Product product)
        {

            ProductService ps = new ProductService(_dbContext);
            int maxId = ps.GetProducts().Result.Value.ToList().Select(x => x.ID).OrderByDescending(x => x).FirstOrDefault();

            if (ModelState.IsValid)
            {
                Product p = new Product();
                p.NAME = product.NAME;
                p.DESCRIPTION = product.DESCRIPTION;
                //p.IMAGEURL = product.IMAGEURL;
                p.ID = maxId + 1;
                _dbContext.Product.Add(p);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Manage));
            }
            return View(product);
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
                user.ID = c.ID;
                user.DESCRIPTION = user.DESCRIPTION;
                
                users.Add(user);
            }

            ProductService ps = new ProductService(_dbContext);
            var resultProducts = ps.GetProducts();

            var products = new List<Product>();
            foreach (var p in resultProducts.Result.Value)
            {
                Product product = new Product();
                product.ID = p.ID;
                product.DESCRIPTION = product.DESCRIPTION;
                product.TYPE = p.TYPE;
                product.ORDER = p.ORDER;

                products.Add(product);
            }

            allInfor.Hotels = hotels;
            allInfor.Flights = flights;
            allInfor.Cruises = cruises;
            allInfor.Users = users;
            allInfor.Products = products;

            var places = _dbContext.Place.ToList();
            allInfor.Places = places;

            return View(allInfor);
            
        }
    }

}
