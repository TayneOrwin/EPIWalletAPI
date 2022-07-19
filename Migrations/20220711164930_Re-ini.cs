using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class Reini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VendorAddresses_Vendors_VendorID",
                table: "VendorAddresses");

            migrationBuilder.DropIndex(
                name: "IX_VendorAddresses_VendorID",
                table: "VendorAddresses");

            migrationBuilder.DeleteData(
                table: "Vendors",
                keyColumn: "VendorID",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "VendorAddressID",
                table: "Vendors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "addressVendorAddressID",
                table: "Vendors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_addressVendorAddressID",
                table: "Vendors",
                column: "addressVendorAddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_VendorAddresses_addressVendorAddressID",
                table: "Vendors",
                column: "addressVendorAddressID",
                principalTable: "VendorAddresses",
                principalColumn: "VendorAddressID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_VendorAddresses_addressVendorAddressID",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_addressVendorAddressID",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "VendorAddressID",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "addressVendorAddressID",
                table: "Vendors");

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Availability", "Description", "Name" },
                values: new object[] { 1, true, "Main Bakery on 4th Street", "Bryan" });

            migrationBuilder.CreateIndex(
                name: "IX_VendorAddresses_VendorID",
                table: "VendorAddresses",
                column: "VendorID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VendorAddresses_Vendors_VendorID",
                table: "VendorAddresses",
                column: "VendorID",
                principalTable: "Vendors",
                principalColumn: "VendorID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
