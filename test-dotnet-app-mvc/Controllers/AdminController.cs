using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_dotnet_app_mvc.Controllers.Service;
using test_dotnet_app_mvc.Models;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;

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
        public async Task<IActionResult> CreateProduct([FromForm] Product product, [FromForm] IEnumerable<IFormFile> images)
        {

            if (images != null && images.Count() > 0)
            {
                var imageUrls = new List<string>();
                var fileName = "";
                foreach (var image in images)
                {
                    if (image.Length > 0)
                    {
                        fileName = Path.GetFileName(image.FileName);
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            image.CopyTo(fileStream);
                        }
                        imageUrls.Add($"/upload/{fileName}");
                    }
                    product.IMAGEURLS += $"/upload/{fileName}";
                    product.IMAGEURLS += ";";
                }
                
                   
            }


            //if (imageFile != null && imageFile.Length > 0)
            //{
            //    // get the file name
            //    string fileName = Path.GetFileName(imageFile.FileName);

            //    // save the file to the server
            //    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", fileName);
            //    using (var stream = new FileStream(path, FileMode.Create))
            //    {
            //        await imageFile.CopyToAsync(stream);
            //    }
            //    ViewBag.url = path;
            //    // redirect back to the index action
            //    return RedirectToAction("CreateProduct", "Admin");
            //}

            ProductService ps = new ProductService(_dbContext);
            int maxId = ps.GetProducts().Result.Value.ToList().Select(x => x.ID).OrderByDescending(x => x).FirstOrDefault();

            if (ModelState.IsValid)
            {
                Product p = new Product();
                p.NAME = product.NAME;
                p.TYPE = product.TYPE;
                
                p.DESCRIPTION = product.DESCRIPTION;
                p.AREA = product.AREA;
                p.COUNTRY = product.COUNTRY;
                p.GROUP_NUMBER = product.GROUP_NUMBER;
                p.DAYS = product.DAYS;
                p.NIGHTS = product.NIGHTS;
                p.DEPARTURE = product.DEPARTURE;
                p.IMAGEURLS = product.IMAGEURLS;
                p.REASON = product.REASON;
                p.TRANSPORTATION = product.TRANSPORTATION;
                p.HOTEL = product.HOTEL;
                p.MEALS = product.MEALS;
                p.ATTRACTIONS = product.ATTRACTIONS;
                p.GROUP_DATE = product.GROUP_DATE;
                p.BOOK_BY_DATE = product.BOOK_BY_DATE;
                p.ADULT_PRICE = product.ADULT_PRICE;
                p.CHILD_PRICE = product.CHILD_PRICE;
                p.SENIOR_PRICE = product.SENIOR_PRICE;
                p.PRICE_INCLUSIVE = product.PRICE_INCLUSIVE;
                p.PRICE_EXCLUSIVE = product.PRICE_EXCLUSIVE;
                p.REFUND_CHANGE_DESCRIPTION = product.REFUND_CHANGE_DESCRIPTION;
                p.REMARK = product.REMARK;
                p.LEAVE_GROUP_CITY = product.LEAVE_GROUP_CITY;
                p.ID = maxId + 1;
                p.ORDER = p.ID;
                p.IMAGEURLS = product.IMAGEURLS;
                _dbContext.Product.Add(p);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Manage));
            }
            return RedirectToAction("Index", "Product");
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
                product.NAME = p.NAME;
                product.ADULT_PRICE = p.ADULT_PRICE;
                product.AREA = p.AREA;
                product.ATTRACTIONS = p.ATTRACTIONS;
                product.BOOK_BY_DATE = p.BOOK_BY_DATE;
                product.CHILD_PRICE = p.CHILD_PRICE;
                product.COUNTRY = p.COUNTRY;
                product.DAYS = p.DAYS;
                product.DEPARTURE = p.DEPARTURE;
                product.GROUP_DATE = p.GROUP_DATE;
                product.GROUP_NUMBER = p.GROUP_NUMBER;
                product.HOTEL = p.HOTEL;
                product.IMAGEURLS = p.IMAGEURLS;
                product.LEAVE_GROUP_CITY = p.LEAVE_GROUP_CITY;
                product.MEALS = p.MEALS;
                product.NIGHTS = p.NIGHTS;
                product.PRICE_EXCLUSIVE = p.PRICE_EXCLUSIVE;
                product.PRICE_INCLUSIVE = p.PRICE_INCLUSIVE;
                product.REASON = p.REASON;
                product.REFUND_CHANGE_DESCRIPTION = p.REFUND_CHANGE_DESCRIPTION;
                product.REMARK = p.REMARK;
                product.SENIOR_PRICE = p.SENIOR_PRICE;
                product.TRANSPORTATION = p.TRANSPORTATION;
                

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

        //public ActionResult UploadImage(HttpPostedFileBase imageFile)
        //{
        //    if (imageFile != null && imageFile.ContentLength > 0)
        //    {
        //        // get the file name
        //        string fileName = Path.GetFileName(imageFile.FileName);

        //        // save the file to the server
        //        string path = Path.Combine(Server.MapPath("~/img/"), fileName);
        //        imageFile.SaveAs(path);

        //        // redirect back to the index action
        //        return RedirectToAction("Index");
        //    }

        //    // if the file was not uploaded, return an error message
        //    ViewBag.ErrorMessage = "Please choose a file to upload.";
        //    return View("Index");
        //}



        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
            {
                // get the file name
                string fileName = Path.GetFileName(imageFile.FileName);

                // save the file to the server
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "upload", fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                ViewBag.url = path;
                // redirect back to the index action
                return RedirectToAction("CreateProduct", "Admin");
            }

            // if the file was not uploaded, return an error message
            ViewBag.ErrorMessage = "Please choose a file to upload.";
            return View("Index");
        }
    
    }

}
