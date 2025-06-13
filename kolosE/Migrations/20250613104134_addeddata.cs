using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kolosE.Migrations
{
    /// <inheritdoc />
    public partial class addeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "FirstName", "HireDate", "LastName" },
                values: new object[] { 1, "John", new DateTime(2025, 6, 13, 12, 41, 34, 305, DateTimeKind.Local).AddTicks(5491), "Doe" });

            migrationBuilder.InsertData(
                table: "Nurseries",
                columns: new[] { "NurseryId", "EstablishedDate", "Name" },
                values: new object[] { 1, new DateTime(2025, 6, 13, 12, 41, 34, 305, DateTimeKind.Local).AddTicks(5633), "aaa" });

            migrationBuilder.InsertData(
                table: "TreeSpecies",
                columns: new[] { "SpeciesId", "GrowthTimeInYears", "LatinName" },
                values: new object[] { 1, 1, "skibidi" });

            migrationBuilder.InsertData(
                table: "SeedlingBatches",
                columns: new[] { "BatchId", "NurseryId", "Quantity", "ReadyDate", "SownDate", "SpeciesId" },
                values: new object[] { 1, 1, 100, new DateTime(2025, 6, 13, 12, 41, 34, 305, DateTimeKind.Local).AddTicks(5673), new DateTime(2025, 6, 13, 12, 41, 34, 305, DateTimeKind.Local).AddTicks(5671), 1 });

            migrationBuilder.InsertData(
                table: "Responsibles",
                columns: new[] { "BatchId", "EmployeeId", "Role" },
                values: new object[] { 1, 1, "worker" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Responsibles",
                keyColumns: new[] { "BatchId", "EmployeeId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SeedlingBatches",
                keyColumn: "BatchId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Nurseries",
                keyColumn: "NurseryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TreeSpecies",
                keyColumn: "SpeciesId",
                keyValue: 1);
        }
    }
}
