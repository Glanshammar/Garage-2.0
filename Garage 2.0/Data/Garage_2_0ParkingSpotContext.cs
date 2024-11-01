using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage_2._0.Models;
using Garage_2._0.Migrations;
using Garage_2._0.Controllers;

namespace Garage_2._0.Data
{
    public class Garage_2_0ParkingSpotContext : DbContext
    {
        Models.Garage garage = new Models.Garage(15,5);
        public Garage_2_0ParkingSpotContext (DbContextOptions<Garage_2_0ParkingSpotContext> options )
            : base(options)
        {
        }

        public DbSet<Garage_2._0.Models.ParkingSpot> ParkingSpot { get; set; } = default!;
    }
}
