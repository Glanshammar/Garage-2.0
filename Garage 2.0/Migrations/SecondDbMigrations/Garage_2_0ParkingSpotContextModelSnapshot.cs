﻿// <auto-generated />
using System;
using Garage_2._0.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Garage_2._0.Migrations.SecondDbMigrations
{
    [DbContext(typeof(Garage_2_0ParkingSpotContext))]
    partial class Garage_2_0ParkingSpotContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("VehicleType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ParkedVehicle");
                });

            modelBuilder.Entity("Garage_2._0.Models.ParkingSpot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("column")
                        .HasColumnType("int");

                    b.Property<bool>("occupied")
                        .HasColumnType("bit");

                    b.Property<int?>("parkedVehicleId")
                        .HasColumnType("int");

                    b.Property<int>("row")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("parkedVehicleId");

                    b.ToTable("ParkingSpot");
                });

            modelBuilder.Entity("Garage_2._0.Models.ParkingSpot", b =>
                {
                    b.HasOne("Garage_2._0.Models.ParkedVehicle", "parkedVehicle")
                        .WithMany()
                        .HasForeignKey("parkedVehicleId");

                    b.Navigation("parkedVehicle");
                });
#pragma warning restore 612, 618
        }
    }
}
