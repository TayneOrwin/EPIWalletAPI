using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class SponsorTale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ExpenseTypes_EventID",
                table: "ExpenseTypes");

            migrationBuilder.AlterColumn<int>(
                name: "EventID",
                table: "Sponsors",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "Sponsors",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Sponsors",
                columns: new[] { "SponsorID", "Amount", "Company", "Email", "EventID", "Surname", "name" },
                values: new object[] { 1, 399.22000000000003, "Striker Investments", "strikerproducts@gmail.com", 17, null, "Bryan" });

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

            migrationBuilder.DeleteData(
                table: "Sponsors",
                keyColumn: "SponsorID",
                keyValue: 1);

            migrationBuilder.AlterColumn<double>(
                name: "EventID",
                table: "Sponsors",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Amount",
                table: "Sponsors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseTypes_EventID",
                table: "ExpenseTypes",
                column: "EventID",
                unique: true);
        }
    }
}
