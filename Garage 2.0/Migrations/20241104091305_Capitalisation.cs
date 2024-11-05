using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_2._0.Migrations
{
    /// <inheritdoc />
    public partial class Capitalisation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "parkingSpot",
                table: "ParkedVehicle",
                newName: "ParkingSpot");

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2024, 11, 4, 10, 13, 4, 337, DateTimeKind.Local).AddTicks(567));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArrivalTime",
                value: new DateTime(2024, 11, 4, 10, 13, 4, 337, DateTimeKind.Local).AddTicks(631));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalTime",
                value: new DateTime(2024, 11, 4, 10, 13, 4, 337, DateTimeKind.Local).AddTicks(636));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ParkingSpot",
                table: "ParkedVehicle",
                newName: "parkingSpot");

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2024, 11, 4, 9, 47, 11, 739, DateTimeKind.Local).AddTicks(5107));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArrivalTime",
                value: new DateTime(2024, 11, 4, 9, 47, 11, 739, DateTimeKind.Local).AddTicks(5195));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalTime",
                value: new DateTime(2024, 11, 4, 9, 47, 11, 739, DateTimeKind.Local).AddTicks(5199));
        }
    }
}
