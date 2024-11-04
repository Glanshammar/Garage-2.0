using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage_2._0.Models;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Garage_2._0.Data
{
    public class Garage_2_0Context : DbContext
    {
        public Garage_2_0Context (DbContextOptions<Garage_2_0Context> options)
            : base(options)
        {
        }

        public DbSet<Garage_2._0.Models.ParkedVehicle> ParkedVehicle { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ParkedVehicle>().HasData(
                new ParkedVehicle { Id=1,VehicleType=VehicleType.Car,RegistrationNumber="ABC123",Color="Blue",Brand="Volkswagen",Model="Jetta",NumberOfWheels=4, ParkingSpot = 0, ParkedColumn=0, ParkedRow=0},
                new ParkedVehicle{ Id = 2 ,VehicleType = VehicleType.Car, RegistrationNumber = "DEF123",Color = "Blue",Brand = "Volkswagen",Model = "Taos",NumberOfWheels = 4, ParkingSpot = 1, ParkedColumn = 0, ParkedRow = 0 },
                new ParkedVehicle { Id = 3, VehicleType = VehicleType.Motorcycle, RegistrationNumber = "CTF345", Color = "Black", Brand = "Something", Model = "OrOther", NumberOfWheels = 2, ParkingSpot = 2, ParkedColumn = 2, ParkedRow = 0 }


                );
        }
    }
}
