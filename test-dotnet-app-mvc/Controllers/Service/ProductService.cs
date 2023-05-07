using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using test_dotnet_app_mvc.Models;

namespace test_dotnet_app_mvc.Controllers.Service
{
    public class ProductService
    {

        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;


        public ProductService(MyDbContext context)
        {
            _context = context;
           

        }

        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {

            try
            {
                var test = _context.Product.ToList();

            }
            catch (Exception exc)
            {
                string t = exc.Message;
                
            }


            var products = _context.Product.ToList();

            //var users = await _context.HET_USER.ToListAsync();
            var result = products;
            return result;
        }
    }

}
