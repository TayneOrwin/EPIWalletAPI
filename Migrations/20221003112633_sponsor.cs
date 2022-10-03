using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class sponsor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sponsors_Events_EventID",
                table: "Sponsors");

            migrationBuilder.DropForeignKey(
                name: "FK_Sponsors_SponsorType_SponsorTypeID",
                table: "Sponsors");

            migrationBuilder.DropIndex(
                name: "IX_Sponsors_EventID",
                table: "Sponsors");

            migrationBuilder.DropIndex(
                name: "IX_Sponsors_SponsorTypeID",
                table: "Sponsors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_EventID",
                table: "Sponsors",
                column: "EventID");

            migrationBuilder.CreateIndex(
                name: "IX_Sponsors_SponsorTypeID",
                table: "Sponsors",
                column: "SponsorTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsors_Events_EventID",
                table: "Sponsors",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sponsors_SponsorType_SponsorTypeID",
                table: "Sponsors",
                column: "SponsorTypeID",
                principalTable: "SponsorType",
                principalColumn: "SponsorTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
