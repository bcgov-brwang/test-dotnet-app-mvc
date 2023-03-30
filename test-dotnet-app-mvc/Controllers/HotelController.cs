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
    public class HotelController : Controller
    {
        private readonly MyDbContext _context;

        public HotelController(MyDbContext context)
        {
            _context = context;


        }
        public IActionResult Index()
        {
            HotelService cs = new HotelService(_context);
            var result = cs.GetHotels();

            var hotels = new List<Hotel>();
            foreach (var p in result.Result.Value)
            {
                Hotel hotel = new Hotel();
                hotel.ID = p.ID;
                hotel.NAME = p.NAME;
                hotel.DESCRIPTION = p.DESCRIPTION;
                hotel.IMAGEURL = p.IMAGEURL;
                //hotel.PRICE = p.PRICE;
                hotels.Add(hotel);
            }

            return View(hotels);
        }


        public IActionResult Edit(int id)
        {
            var hotel = _context.Hotel.Find(id);
            return View(hotel);
        }

        [HttpPost]
        public IActionResult Edit(Hotel hotel)
        {
            _context.Hotel.Update(hotel);
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

            var hotel = await _context.Hotel
                .FirstOrDefaultAsync(m => m.ID == id);
            if (hotel == null)
            {
                return NotFound();
            }

            return View(hotel);
        }

        // POST: Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hotel = await _context.Hotel.FindAsync(id);
            _context.Hotel.Remove(hotel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Detail(int id)
        {
            var hotel = _context.Hotel.ToList().Where(x => x.ID == id).FirstOrDefault();
            return View(hotel);
        }


    }
}
