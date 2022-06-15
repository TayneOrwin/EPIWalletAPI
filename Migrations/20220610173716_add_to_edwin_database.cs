using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class add_to_edwin_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExpenseTypes_EventID",
                table: "ExpenseTypes");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTypes_EventID",
                table: "ExpenseTypes",
                column: "EventID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExpenseTypes_EventID",
                table: "ExpenseTypes");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTypes_EventID",
                table: "ExpenseTypes",
                column: "EventID",
                unique: true);
        }
    }
}
