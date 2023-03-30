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
    public class UserController : Controller
    {
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;


        }

        public IActionResult Nonuser()
        {
            return View();
        }


        public IActionResult Edit(int id)
        {
            var user = _context.User.Find(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            _context.User.Update(user);
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

            var user = await _context.User
                .FirstOrDefaultAsync(m => m.USER_ID == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.User.FindAsync(id);
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Detail(int id)
        {
            var user = _context.User.ToList().Where(x => x.USER_ID == id).FirstOrDefault();
            return View(user);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid)
            {
                // TODO: Register user logic
                UserService us = new UserService(_context);
                await us.Register(user);
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                // TODO: Login user logic
                UserService us = new UserService(_context);
                bool isUser = await us.Login(user);
                if (isUser)
                {
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    return RedirectToAction("Nonuser", "User");
                }
                
            }

            return View(user);
        }

    }
}
