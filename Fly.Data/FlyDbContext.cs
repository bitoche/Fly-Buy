using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly.Data
{
    public class FlyDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Flight> Flights { get; set; }

        public FlyDbContext(DbContextOptions options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildPlanes(modelBuilder);
            BuildUsers(modelBuilder);
            BuildFlights(modelBuilder);
        }

        private void BuildPlanes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plane>();
        }
        private void BuildUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>();
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 2,
                    Name = "Admin",
                    Login = "Administrator-1@admin.admin",
                    Password = "c2ef3e415f01b83cf65108505daefccb0e032ccb1aabf45ac0541426a56dbfa5",
                    Role = Role.Administrator,
                    Balance = 99999999999,
                }) ;
        }
        private void BuildFlights(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>();
        }

    }
}
