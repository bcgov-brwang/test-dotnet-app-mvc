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
        public IActionResult Index()
        {
            ProductService ps = new ProductService(_context);
            var result = ps.GetProducts();

            var products = new List<Product>();
            foreach (var p in result.Result.Value)
            {
                Product product = new Product();
                product.ID = p.ID;
                product.NAME = p.NAME;
                product.DESCRIPTION = p.DESCRIPTION;
                product.IMAGEURLS = p.IMAGEURLS;
                //hotel.PRICE = p.PRICE;
                products.Add(product);
            }

            return View(products);
        }

        public ActionResult Detail(int id)
        {
            var product = _context.Product.ToList().Where(x => x.ID == id).FirstOrDefault();
            return View(product);
        }



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
