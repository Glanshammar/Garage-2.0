﻿// <auto-generated />
using System;
using Garage_2._0.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Garage_2._0.Migrations
{
    [DbContext(typeof(Garage_2_0Context))]
    [Migration("20241104091305_Capitalisation")]
    partial class Capitalisation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Garage_2._0.Models.ParkedVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfWheels")
                        .HasColumnType("int");

                    b.Property<int>("ParkingSpot")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ParkedVehicle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArrivalTime = new DateTime(2024, 11, 4, 10, 13, 4, 337, DateTimeKind.Local).AddTicks(567),
                            Brand = "Volkswagen",
                            Color = "Blue",
                            Model = "Jetta",
                            NumberOfWheels = 4,
                            ParkingSpot = 1,
                            RegistrationNumber = "ABC123",
                            VehicleType = 0
                        },
                        new
                        {
                            Id = 2,
                            ArrivalTime = new DateTime(2024, 11, 4, 10, 13, 4, 337, DateTimeKind.Local).AddTicks(631),
                            Brand = "Volkswagen",
                            Color = "Blue",
                            Model = "Taos",
                            NumberOfWheels = 4,
                            ParkingSpot = 2,
                            RegistrationNumber = "DEF123",
                            VehicleType = 0
                        },
                        new
                        {
                            Id = 3,
                            ArrivalTime = new DateTime(2024, 11, 4, 10, 13, 4, 337, DateTimeKind.Local).AddTicks(636),
                            Brand = "Something",
                            Color = "Black",
                            Model = "OrOther",
                            NumberOfWheels = 2,
                            ParkingSpot = 3,
                            RegistrationNumber = "CTF345",
                            VehicleType = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
