using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_dotnet_app_mvc.Models;


namespace test_dotnet_app_mvc
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Place> Place { get; set; }

        public DbSet<Cruise> Cruise { get; set; }
        public DbSet<Hotel> Hotel { get; set; }

        public DbSet<Flight> Flight { get; set; }

        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.ID);

            modelBuilder.Entity<Place>()
                .HasKey(p => p.ID);
        }
    }
}
