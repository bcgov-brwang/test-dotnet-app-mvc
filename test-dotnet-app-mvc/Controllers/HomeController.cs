using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using test_dotnet_app_mvc.Controllers.Service;
using test_dotnet_app_mvc.Models;

namespace test_dotnet_app_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        private readonly MyDbContext _context;
        public static int UserId;
        public static bool IsAdmin;



        public async Task<IActionResult> Index()
        {

            var user = _context.User.Where(x => x.ID == HomeController.UserId).FirstOrDefault();
            if (user != null)
            {
                UserRole ur = _context.UserRole.Where(x => x.ID == user.ID).FirstOrDefault();
                if (ur.ROLE_ID == 1)
                {
                    ViewBag.IsAdmin = true;
                }
                else
                {
                    ViewBag.IsAdmin = false;
                }


            }

            if (user == null)
            {

                var result = new User();
                return View(result);
            }
            else
            {
                
                ViewBag.UserName = user.USERNAME;
                return View(user);

            }
        }

        public IActionResult Test()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
