using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_dotnet_app_mvc.Controllers.Service;
using test_dotnet_app_mvc.Models;

namespace test_dotnet_app_mvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyDbContext _context;

        public ProductController(MyDbContext context)
        {
            _context = context;


        }
        //public IActionResult Index()
        //{
        //    HotelService cs = new HotelService(_context);
        //    var result = cs.GetHotels();

        //    var hotels = new List<Hotel>();
        //    foreach (var p in result.Result.Value)
        //    {
        //        Hotel hotel = new Hotel();
        //        hotel.ID = p.ID;
        //        hotel.NAME = p.NAME;
        //        hotel.DESCRIPTION = p.DESCRIPTION;
        //        hotel.IMAGEURL = p.IMAGEURL;
        //        //hotel.PRICE = p.PRICE;
        //        hotels.Add(hotel);
        //    }

        //    return View(hotels);
        //}


        public IActionResult Edit(int id)
        {
            var product = _context.Product.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            _context.Product.Update(product);
            _context.SaveChanges();
            return RedirectToAction("Manage", "Admin");
        }

        // GET: Hotel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.ID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Manage", "Admin");
        }

        //public ActionResult Detail(int id)
        //{
        //    var hotel = _context.Hotel.ToList().Where(x => x.ID == id).FirstOrDefault();
        //    return View(hotel);
        //}


    }
}
