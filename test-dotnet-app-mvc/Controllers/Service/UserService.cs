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
    public class UserService
    {

        private readonly MyDbContext _context;
        private readonly IConfiguration _configuration;


        public UserService(MyDbContext context)
        {
            _context = context;
           

        }

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {

            try
            {
                var test = _context.User.ToList();

            }
            catch (Exception exc)
            {
                string t = exc.Message;
                
            }


            var users = _context.User.ToList();

            //var users = await _context.HET_USER.ToListAsync();
            var result = users;
            return result;
        }

        public async Task<ActionResult<User>> GetUser(int id)
        {
            User user = null;

            try
            {
                user = _context.User.ToList().Where(x => x.ID == id).FirstOrDefault();

            }
            catch (Exception exc)
            {
                string t = exc.Message;

            }

            return user;
        }


        public async Task Register(User user)
        {
            user.ID = _context.User.Select(x => x.ID).OrderByDescending(x => x).FirstOrDefault() + 1;
            _context.Add(user);

            
            var ur = _context.UserRole.OrderByDescending(x => x.ID).FirstOrDefault();
            if (ur == null)
            {
                ur = new UserRole();
                ur.USER_ID = user.ID;
                ur.ROLE_ID = 1;
                ur.ID = 1;
            }
            else
            {
                var newUserRole = new UserRole();
                newUserRole.ID = ur.ID + 1;
                newUserRole.USER_ID = user.ID;
                newUserRole.ROLE_ID = 2;
                ur = newUserRole;
                
            }
            _context.Add(ur);

            await _context.SaveChangesAsync();
  
        }


        public async Task<User> Login(User user)
        {
            User result = null;
            User existingUser = _context.User.Where(x => x.EMAIL == user.EMAIL && x.PASSWORD == user.PASSWORD).FirstOrDefault();
            if (existingUser != null)
            {
                result = existingUser;
            }
            
            return result;

        }
    }

}
