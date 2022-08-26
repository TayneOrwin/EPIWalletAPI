using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class change_name_to_proof : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_proodOfPayment_expenseLines_ExpenseLineID",
                table: "proodOfPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_proodOfPayment",
                table: "proodOfPayment");

            migrationBuilder.RenameTable(
                name: "proodOfPayment",
                newName: "proofOfPayment");

            migrationBuilder.RenameIndex(
                name: "IX_proodOfPayment_ExpenseLineID",
                table: "proofOfPayment",
                newName: "IX_proofOfPayment_ExpenseLineID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_proofOfPayment",
                table: "proofOfPayment",
                column: "ProofOfPaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_proofOfPayment_expenseLines_ExpenseLineID",
                table: "proofOfPayment",
                column: "ExpenseLineID",
                principalTable: "expenseLines",
                principalColumn: "ExpenseLineID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_proofOfPayment_expenseLines_ExpenseLineID",
                table: "proofOfPayment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_proofOfPayment",
                table: "proofOfPayment");

            migrationBuilder.RenameTable(
                name: "proofOfPayment",
                newName: "proodOfPayment");

            migrationBuilder.RenameIndex(
                name: "IX_proofOfPayment_ExpenseLineID",
                table: "proodOfPayment",
                newName: "IX_proodOfPayment_ExpenseLineID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_proodOfPayment",
                table: "proodOfPayment",
                column: "ProofOfPaymentID");

            migrationBuilder.AddForeignKey(
                name: "FK_proodOfPayment_expenseLines_ExpenseLineID",
                table: "proodOfPayment",
                column: "ExpenseLineID",
                principalTable: "expenseLines",
                principalColumn: "ExpenseLineID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
