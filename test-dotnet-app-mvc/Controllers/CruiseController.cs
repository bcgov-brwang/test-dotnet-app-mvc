using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_dotnet_app_mvc.Controllers.Service;
using test_dotnet_app_mvc.Models;

namespace test_dotnet_app_mvc.Controllers
{
    public class CruiseController : Controller
    {
        private readonly MyDbContext _context;

        public CruiseController(MyDbContext context)
        {
            _context = context;


        }
        public IActionResult Index()
        {
            CruiseService cs = new CruiseService(_context);
            var result = cs.GetCruises();

            var cruises = new List<Cruise>();
            foreach (var p in result.Result.Value)
            {
                Cruise cruise = new Cruise();
                cruise.ID = p.ID;
                cruise.NAME = p.NAME;
                cruise.DESCRIPTION = p.DESCRIPTION;
                cruise.IMAGEURL = p.IMAGEURL;
                cruise.PRICE = p.PRICE;
                cruises.Add(cruise);
            }

            return View(cruises);
        }
    }
}
