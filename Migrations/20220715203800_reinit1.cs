using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class reinit1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_VendorAddresses_addressVendorAddressID",
                table: "Vendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendorAddresses",
                table: "VendorAddresses");

            migrationBuilder.RenameTable(
                name: "VendorAddresses",
                newName: "VendorAddress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendorAddress",
                table: "VendorAddress",
                column: "VendorAddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_VendorAddress_addressVendorAddressID",
                table: "Vendors",
                column: "addressVendorAddressID",
                principalTable: "VendorAddress",
                principalColumn: "VendorAddressID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_VendorAddress_addressVendorAddressID",
                table: "Vendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VendorAddress",
                table: "VendorAddress");

            migrationBuilder.RenameTable(
                name: "VendorAddress",
                newName: "VendorAddresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VendorAddresses",
                table: "VendorAddresses",
                column: "VendorAddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_VendorAddresses_addressVendorAddressID",
                table: "Vendors",
                column: "addressVendorAddressID",
                principalTable: "VendorAddresses",
                principalColumn: "VendorAddressID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
