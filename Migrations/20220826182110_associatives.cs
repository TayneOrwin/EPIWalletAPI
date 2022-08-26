using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class associatives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employeeExpenseLine",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    ExpenseLineID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeExpenseLine", x => x.id);
                    table.ForeignKey(
                        name: "FK_employeeExpenseLine_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_employeeExpenseLine_expenseLines_ExpenseLineID",
                        column: x => x.ExpenseLineID,
                        principalTable: "expenseLines",
                        principalColumn: "ExpenseLineID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "expenseLineRequest",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExpenseID = table.Column<int>(type: "int", nullable: true),
                    ExpenseLineID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_expenseLineRequest", x => x.id);
                    table.ForeignKey(
                        name: "FK_expenseLineRequest_expenseLines_ExpenseLineID",
                        column: x => x.ExpenseLineID,
                        principalTable: "expenseLines",
                        principalColumn: "ExpenseLineID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_expenseLineRequest_ExpenseRequests_ExpenseID",
                        column: x => x.ExpenseID,
                        principalTable: "ExpenseRequests",
                        principalColumn: "ExpenseID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "guestInvite",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventInviteID = table.Column<int>(type: "int", nullable: true),
                    GuestID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guestInvite", x => x.id);
                    table.ForeignKey(
                        name: "FK_guestInvite_EventInvites_EventInviteID",
                        column: x => x.EventInviteID,
                        principalTable: "EventInvites",
                        principalColumn: "EventInviteID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_guestInvite_Guests_GuestID",
                        column: x => x.GuestID,
                        principalTable: "Guests",
                        principalColumn: "GuestID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employeeExpenseLine_EmployeeID",
                table: "employeeExpenseLine",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_employeeExpenseLine_ExpenseLineID",
                table: "employeeExpenseLine",
                column: "ExpenseLineID");

            migrationBuilder.CreateIndex(
                name: "IX_expenseLineRequest_ExpenseID",
                table: "expenseLineRequest",
                column: "ExpenseID");

            migrationBuilder.CreateIndex(
                name: "IX_expenseLineRequest_ExpenseLineID",
                table: "expenseLineRequest",
                column: "ExpenseLineID");

            migrationBuilder.CreateIndex(
                name: "IX_guestInvite_EventInviteID",
                table: "guestInvite",
                column: "EventInviteID");

            migrationBuilder.CreateIndex(
                name: "IX_guestInvite_GuestID",
                table: "guestInvite",
                column: "GuestID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeeExpenseLine");

            migrationBuilder.DropTable(
                name: "expenseLineRequest");

            migrationBuilder.DropTable(
                name: "guestInvite");
        }
    }
}
