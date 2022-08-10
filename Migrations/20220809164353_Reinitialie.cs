using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class Reinitialie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenseLines_ExpenseRequests_ExpenseRequestExpenseID",
                table: "expenseLines");

            migrationBuilder.DropIndex(
                name: "IX_expenseLines_ExpenseRequestExpenseID",
                table: "expenseLines");

            migrationBuilder.DropColumn(
                name: "ExpenseRequestExpenseID",
                table: "expenseLines");

            migrationBuilder.RenameColumn(
                name: "ExpenseID",
                table: "expenseLines",
                newName: "ExpenseRequestID");

            migrationBuilder.CreateIndex(
                name: "IX_expenseLines_ExpenseRequestID",
                table: "expenseLines",
                column: "ExpenseRequestID");

            migrationBuilder.AddForeignKey(
                name: "FK_expenseLines_ExpenseRequests_ExpenseRequestID",
                table: "expenseLines",
                column: "ExpenseRequestID",
                principalTable: "ExpenseRequests",
                principalColumn: "ExpenseID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenseLines_ExpenseRequests_ExpenseRequestID",
                table: "expenseLines");

            migrationBuilder.DropIndex(
                name: "IX_expenseLines_ExpenseRequestID",
                table: "expenseLines");

            migrationBuilder.RenameColumn(
                name: "ExpenseRequestID",
                table: "expenseLines",
                newName: "ExpenseID");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseRequestExpenseID",
                table: "expenseLines",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_expenseLines_ExpenseRequestExpenseID",
                table: "expenseLines",
                column: "ExpenseRequestExpenseID");

            migrationBuilder.AddForeignKey(
                name: "FK_expenseLines_ExpenseRequests_ExpenseRequestExpenseID",
                table: "expenseLines",
                column: "ExpenseRequestExpenseID",
                principalTable: "ExpenseRequests",
                principalColumn: "ExpenseID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
