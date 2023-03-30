using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_dotnet_app_mvc.Models;

namespace test_dotnet_app_mvc.Controllers.Service
{
    public class CustomizeService
    {
        private readonly MyDbContext _context;

        public CustomizeService(MyDbContext context)
        {
            _context = context;


        }

        public IEnumerable<CustomizeServiceModel> GetServices()
        {

            var customizes = new List<CustomizeServiceModel>
            {
                new CustomizeServiceModel { Name = "Tourist Visa", Description = "Allows travel for tourism purposes", Price = 100},
                new CustomizeServiceModel { Name = "Business Visa", Description = "Allows travel for business purposes", Price = 150 },
                new CustomizeServiceModel { Name = "Student Visa", Description = "Allows travel for educational purposes", Price = 200},
                new CustomizeServiceModel { Name = "Work Visa", Description = "Allows travel for work purposes", Price = 250 }
            };

            return customizes.ToList();
        }

    }
}
