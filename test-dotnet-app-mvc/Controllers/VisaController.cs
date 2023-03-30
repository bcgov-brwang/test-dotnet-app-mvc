using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_dotnet_app_mvc.Controllers.Service;
using test_dotnet_app_mvc.Models;

namespace test_dotnet_app_mvc.Controllers
{
    public class VisaController : Controller
    {
        private readonly MyDbContext _context;

        public VisaController(MyDbContext context)
        {
            _context = context;
        }
          
        public IActionResult Index()
        {

            VisaService vs = new VisaService(_context);
            var result = vs.GetServices();

            var services = new List<VisaServiceModel>();
            foreach (var v in result)
            {
                VisaServiceModel visaServiceModel = new VisaServiceModel();
                visaServiceModel.Id = v.Id;
                visaServiceModel.Name = v.Name;
                visaServiceModel.Description = v.Description;
                visaServiceModel.Price = v.Price;
                services.Add(visaServiceModel);
            }

            return View(result);

        }
    }
}
