using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class VendorPart1Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    VendorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Availability = table.Column<bool>(type: "bit", nullable: false),
                    VendorAddressID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.VendorID);
                });

            migrationBuilder.CreateTable(
                name: "VendorAddresses",
                columns: table => new
                {
                    VendorAddressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorID = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Suburb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VendorID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorAddresses", x => x.VendorAddressID);
                    table.ForeignKey(
                        name: "FK_VendorAddresses_Vendors_VendorID1",
                        column: x => x.VendorID1,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Sponsors",
                keyColumn: "SponsorID",
                keyValue: 1,
                column: "Surname",
                value: "Heuston");

            migrationBuilder.InsertData(
                table: "VendorAddresses",
                columns: new[] { "VendorAddressID", "AddressLine1", "AddressLine2", "Country", "Province", "Suburb", "VendorID", "VendorID1" },
                values: new object[] { 1, "578 Saint Street", "No 57", "South Africa", "Gauteng", "Menlo Park", 1, null });

            migrationBuilder.InsertData(
                table: "Vendors",
                columns: new[] { "VendorID", "Availability", "Description", "Name", "VendorAddressID" },
                values: new object[] { 1, true, "Main Bakery on 4th Street", "Bryan", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_VendorAddresses_VendorID1",
                table: "VendorAddresses",
                column: "VendorID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VendorAddresses");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.UpdateData(
                table: "Sponsors",
                keyColumn: "SponsorID",
                keyValue: 1,
                column: "Surname",
                value: null);
        }
    }
}
