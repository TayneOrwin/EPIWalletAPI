using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class add_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventID", "TypeID", "date", "description", "name" },
                values: new object[] { 1, 1, new DateTime(2009, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Organized work social by the team", "Work Social" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventID", "TypeID", "date", "description", "name" },
                values: new object[] { 2, 1, new DateTime(2009, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Organized Breakfast", "Morning Social" });

            migrationBuilder.InsertData(
                table: "ExpenseTypes",
                columns: new[] { "TypeID", "EventID", "Type" },
                values: new object[] { 1, 1, "Social" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ExpenseTypes",
                keyColumn: "TypeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "EventID",
                keyValue: 1);
        }
    }
}
