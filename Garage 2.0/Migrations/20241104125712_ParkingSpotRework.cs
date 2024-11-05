using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_2._0.Migrations
{
    /// <inheritdoc />
    public partial class ParkingSpotRework : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParkedColumn",
                table: "ParkedVehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParkedRow",
                table: "ParkedVehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "ParkedColumn", "ParkedRow", "ParkingSpot" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 57, 10, 751, DateTimeKind.Local).AddTicks(4163), 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "ParkedColumn", "ParkedRow", "ParkingSpot" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 57, 10, 751, DateTimeKind.Local).AddTicks(4222), 0, 0, 1 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "ParkedColumn", "ParkedRow", "ParkingSpot" },
                values: new object[] { new DateTime(2024, 11, 4, 13, 57, 10, 751, DateTimeKind.Local).AddTicks(4227), 2, 0, 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParkedColumn",
                table: "ParkedVehicle");

            migrationBuilder.DropColumn(
                name: "ParkedRow",
                table: "ParkedVehicle");

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "ParkingSpot" },
                values: new object[] { new DateTime(2024, 11, 4, 10, 13, 4, 337, DateTimeKind.Local).AddTicks(567), 1 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "ParkingSpot" },
                values: new object[] { new DateTime(2024, 11, 4, 10, 13, 4, 337, DateTimeKind.Local).AddTicks(631), 2 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "ParkingSpot" },
                values: new object[] { new DateTime(2024, 11, 4, 10, 13, 4, 337, DateTimeKind.Local).AddTicks(636), 3 });
        }
    }
}
