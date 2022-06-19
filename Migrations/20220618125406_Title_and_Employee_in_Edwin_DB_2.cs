using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class Title_and_Employee_in_Edwin_DB_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Titles_DescriptionTitleID",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "DescriptionTitleID",
                table: "Employees",
                newName: "TitlesTitleID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DescriptionTitleID",
                table: "Employees",
                newName: "IX_Employees_TitlesTitleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Titles_TitlesTitleID",
                table: "Employees",
                column: "TitlesTitleID",
                principalTable: "Titles",
                principalColumn: "TitleID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Titles_TitlesTitleID",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "TitlesTitleID",
                table: "Employees",
                newName: "DescriptionTitleID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_TitlesTitleID",
                table: "Employees",
                newName: "IX_Employees_DescriptionTitleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Titles_DescriptionTitleID",
                table: "Employees",
                column: "DescriptionTitleID",
                principalTable: "Titles",
                principalColumn: "TitleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
