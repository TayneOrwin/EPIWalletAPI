using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class companyandcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectCodes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    code = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectCodes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectCodeID = table.Column<int>(type: "int", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    projectcodes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);
                    table.ForeignKey(
                        name: "FK_Companies_ProjectCodes_ProjectCodeID",
                        column: x => x.ProjectCodeID,
                        principalTable: "ProjectCodes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Companies_ProjectCodeID",
                table: "Companies",
                column: "ProjectCodeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "ProjectCodes");
        }
    }
}
