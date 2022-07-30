using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAddress_Employees_EmployeeID",
                table: "EmployeeAddress");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "EmployeeAddress",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAddress_Employees_EmployeeID",
                table: "EmployeeAddress",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeAddress_Employees_EmployeeID",
                table: "EmployeeAddress");

            migrationBuilder.AlterColumn<int>(
                name: "EmployeeID",
                table: "EmployeeAddress",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeAddress_Employees_EmployeeID",
                table: "EmployeeAddress",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
