using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseTypes_Events_EventID",
                table: "ExpenseTypes");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseTypes_EventID",
                table: "ExpenseTypes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTypes_EventID",
                table: "ExpenseTypes",
                column: "EventID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseTypes_Events_EventID",
                table: "ExpenseTypes",
                column: "EventID",
                principalTable: "Events",
                principalColumn: "EventID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
