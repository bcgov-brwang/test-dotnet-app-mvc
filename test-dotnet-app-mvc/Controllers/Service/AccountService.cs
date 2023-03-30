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
    public class AccountService
    {

        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;



        public AccountService(MyDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddAccount(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }
    }

}
