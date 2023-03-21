using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_dotnet_app_mvc.Controllers.Service;

namespace test_dotnet_app_mvc.Controllers
{
    public class UserController : Controller
    {
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;


        }

        public IActionResult Index()
        {
            UserService us = new UserService(_context);
            var result = us.GetUsers();
            return View(result.Result.Value);
        }

       
    }
}
