using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class province_and_vendortype_lookup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Province",
                table: "EmployeeAddress");

            migrationBuilder.AddColumn<string>(
                name: "VendorTypeID",
                table: "Vendors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorTypeID1",
                table: "Vendors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProvinceID",
                table: "EmployeeAddress",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceDesctiption = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceID);
                });

            migrationBuilder.CreateTable(
                name: "VendorType",
                columns: table => new
                {
                    VendorTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VendorType", x => x.VendorTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vendors_VendorTypeID1",
                table: "Vendors",
                column: "VendorTypeID1");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddress_ProvinceID",
                table: "EmployeeAddress",
                column: "ProvinceID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAddress_Province_ProvinceID",
                table: "EmployeeAddress",
                column: "ProvinceID",
                principalTable: "Province",
                principalColumn: "ProvinceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vendors_VendorType_VendorTypeID1",
                table: "Vendors",
                column: "VendorTypeID1",
                principalTable: "VendorType",
                principalColumn: "VendorTypeID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAddress_Province_ProvinceID",
                table: "EmployeeAddress");

            migrationBuilder.DropForeignKey(
                name: "FK_Vendors_VendorType_VendorTypeID1",
                table: "Vendors");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "VendorType");

            migrationBuilder.DropIndex(
                name: "IX_Vendors_VendorTypeID1",
                table: "Vendors");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeAddress_ProvinceID",
                table: "EmployeeAddress");

            migrationBuilder.DropColumn(
                name: "VendorTypeID",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "VendorTypeID1",
                table: "Vendors");

            migrationBuilder.DropColumn(
                name: "ProvinceID",
                table: "EmployeeAddress");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                table: "EmployeeAddress",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
