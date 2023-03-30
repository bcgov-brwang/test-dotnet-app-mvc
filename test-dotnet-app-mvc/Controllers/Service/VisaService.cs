using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_dotnet_app_mvc.Models;

namespace test_dotnet_app_mvc.Controllers.Service
{
    public class VisaService
    {
        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;

        public VisaService(MyDbContext context)
        {
            _context = context;


        }

        public IEnumerable<VisaServiceModel> GetServices()
        {

            var services = new List<VisaServiceModel>
            {
                new VisaServiceModel { Name = "Tourist Visa", Description = "Allows travel for tourism purposes", Price = 100, ImageUrl = "img/v-1.jpg"},
                new VisaServiceModel { Name = "Business Visa", Description = "Allows travel for business purposes", Price = 150, ImageUrl = "img/v-2.jpg" },
                new VisaServiceModel { Name = "Student Visa", Description = "Allows travel for educational purposes", Price = 200, ImageUrl = "img/v-3.png" },
                new VisaServiceModel { Name = "Work Visa", Description = "Allows travel for work purposes", Price = 250, ImageUrl = "img/v-4.jpg" }
            };

            return services.ToList();
        }

    }
}
