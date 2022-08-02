using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class expenseitemandstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExpenseRequest",
                columns: table => new
                {
                    ExpenseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseRequest", x => x.ExpenseID);
                    table.ForeignKey(
                        name: "FK_ExpenseRequest_ExpenseTypes_TypeID1",
                        column: x => x.TypeID1,
                        principalTable: "ExpenseTypes",
                        principalColumn: "TypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusID);
                });

            migrationBuilder.CreateTable(
                name: "expenseItems",
                columns: table => new
                {
                    ExpenseItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseID1 = table.Column<int>(type: "int", nullable: true),
                    itemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    estimateCost = table.Column<double>(type: "float", nullable: false),
                    itemDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenseItems", x => x.ExpenseItemID);
                    table.ForeignKey(
                        name: "FK_expenseItems_ExpenseRequest_ExpenseID1",
                        column: x => x.ExpenseID1,
                        principalTable: "ExpenseRequest",
                        principalColumn: "ExpenseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_expenseItems_ExpenseID1",
                table: "expenseItems",
                column: "ExpenseID1");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseRequest_TypeID1",
                table: "ExpenseRequest",
                column: "TypeID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "expenseItems");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "ExpenseRequest");
        }
    }
}
