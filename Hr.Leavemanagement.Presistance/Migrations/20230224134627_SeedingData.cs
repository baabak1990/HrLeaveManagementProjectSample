using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Hr.Leavemanagement.Presistance.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "DefaultDays", "ModifiedBy", "ModifyDate", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, null, "vacation" },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, null, null, "Sick" }
                });

            migrationBuilder.InsertData(
                table: "LeaveAllocations",
                columns: new[] { "Id", "CreateDate", "CreatedBy", "LeaveTypeId", "ModifiedBy", "ModifyDate", "NumberOfDays", "Period" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, null, 3, 1 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, null, 5, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LeaveAllocations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LeaveAllocations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LeaveTypes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
