using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class reiitalization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "VendorAddresses",
                keyColumn: "VendorAddressID",
                keyValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VendorAddresses",
                columns: new[] { "VendorAddressID", "AddressLine1", "AddressLine2", "Country", "Province", "Suburb", "VendorID" },
                values: new object[] { 1, "578 Saint Street", "No 57", "South Africa", "Gauteng", "Menlo Park", 1 });
        }
    }
}
