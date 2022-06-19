using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class reinit_edwin_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Titles_TitlesTitleID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TitlesTitleID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "TitlesTitleID",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "TitleID",
                table: "Titles",
                newName: "TitlesID");

            migrationBuilder.RenameColumn(
                name: "TitleID",
                table: "Employees",
                newName: "TitlesID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TitlesID",
                table: "Employees",
                column: "TitlesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Titles_TitlesID",
                table: "Employees",
                column: "TitlesID",
                principalTable: "Titles",
                principalColumn: "TitlesID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Titles_TitlesID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_TitlesID",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "TitlesID",
                table: "Titles",
                newName: "TitleID");

            migrationBuilder.RenameColumn(
                name: "TitlesID",
                table: "Employees",
                newName: "TitleID");

            migrationBuilder.AddColumn<int>(
                name: "TitlesTitleID",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_TitlesTitleID",
                table: "Employees",
                column: "TitlesTitleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Titles_TitlesTitleID",
                table: "Employees",
                column: "TitlesTitleID",
                principalTable: "Titles",
                principalColumn: "TitleID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
