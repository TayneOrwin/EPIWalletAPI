using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class sponsor_table_to_Edwin_local_DB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sponsors",
                keyColumn: "SponsorID",
                keyValue: 1,
                column: "Surname",
                value: "Heuston");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sponsors",
                keyColumn: "SponsorID",
                keyValue: 1,
                column: "Surname",
                value: null);
        }
    }
}
