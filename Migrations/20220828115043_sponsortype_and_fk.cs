using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class sponsortype_and_fk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SponsorTypeID",
                table: "Sponsors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SponsorType",
                columns: table => new
                {
                    SponsorTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SponsorType", x => x.SponsorTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_SponsorTypeID",
                table: "Sponsors",
                column: "SponsorTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsors_SponsorType_SponsorTypeID",
                table: "Sponsors",
                column: "SponsorTypeID",
                principalTable: "SponsorType",
                principalColumn: "SponsorTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sponsors_SponsorType_SponsorTypeID",
                table: "Sponsors");

            migrationBuilder.DropTable(
                name: "SponsorType");

            migrationBuilder.DropIndex(
                name: "IX_Sponsors_SponsorTypeID",
                table: "Sponsors");

            migrationBuilder.DropColumn(
                name: "SponsorTypeID",
                table: "Sponsors");
        }
    }
}
