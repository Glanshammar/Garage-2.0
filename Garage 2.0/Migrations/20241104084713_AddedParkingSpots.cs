using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Garage_2._0.Migrations
{
    /// <inheritdoc />
    public partial class AddedParkingSpots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "ParkedVehicle",
                type: "nvarchar(6)",
                maxLength: 6,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "parkingSpot",
                table: "ParkedVehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArrivalTime", "parkingSpot" },
                values: new object[] { new DateTime(2024, 11, 4, 9, 47, 11, 739, DateTimeKind.Local).AddTicks(5107), 1 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArrivalTime", "parkingSpot" },
                values: new object[] { new DateTime(2024, 11, 4, 9, 47, 11, 739, DateTimeKind.Local).AddTicks(5195), 2 });

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ArrivalTime", "parkingSpot" },
                values: new object[] { new DateTime(2024, 11, 4, 9, 47, 11, 739, DateTimeKind.Local).AddTicks(5199), 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "parkingSpot",
                table: "ParkedVehicle");

            migrationBuilder.AlterColumn<string>(
                name: "RegistrationNumber",
                table: "ParkedVehicle",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(6)",
                oldMaxLength: 6);

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "ArrivalTime",
                value: new DateTime(2024, 10, 30, 14, 6, 8, 649, DateTimeKind.Local).AddTicks(817));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "ArrivalTime",
                value: new DateTime(2024, 10, 30, 14, 6, 8, 649, DateTimeKind.Local).AddTicks(877));

            migrationBuilder.UpdateData(
                table: "ParkedVehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "ArrivalTime",
                value: new DateTime(2024, 10, 30, 14, 6, 8, 649, DateTimeKind.Local).AddTicks(882));
        }
    }
}
