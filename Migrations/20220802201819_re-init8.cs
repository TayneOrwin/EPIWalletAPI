using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class reinit8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_expenseItems_ExpenseRequest_ExpenseID1",
                table: "expenseItems");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_expenseItems",
                table: "expenseItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseRequest",
                table: "ExpenseRequest");

            migrationBuilder.RenameTable(
                name: "expenseItems",
                newName: "ExpenseItems");

            migrationBuilder.RenameTable(
                name: "ExpenseRequest",
                newName: "ExpenseRequests");

            migrationBuilder.RenameIndex(
                name: "IX_expenseItems_ExpenseID1",
                table: "ExpenseItems",
                newName: "IX_ExpenseItems_ExpenseID1");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseRequest_TypeID1",
                table: "ExpenseRequests",
                newName: "IX_ExpenseRequests_TypeID1");

            migrationBuilder.AddColumn<int>(
                name: "ApprovalID1",
                table: "ExpenseRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID1",
                table: "ExpenseRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VendorID1",
                table: "ExpenseRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "totalEstimate",
                table: "ExpenseRequests",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseItems",
                table: "ExpenseItems",
                column: "ExpenseItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseRequests",
                table: "ExpenseRequests",
                column: "ExpenseID");

            migrationBuilder.CreateTable(
                name: "approvalStatuses",
                columns: table => new
                {
                    ApprovalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_approvalStatuses", x => x.ApprovalID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCodes",
                columns: table => new
                {
                    productCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VendorID1 = table.Column<int>(type: "int", nullable: true),
                    EventID1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCodes", x => x.productCode);
                    table.ForeignKey(
                        name: "FK_ProductCodes_Events_EventID1",
                        column: x => x.EventID1,
                        principalTable: "Events",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCodes_Vendors_VendorID1",
                        column: x => x.VendorID1,
                        principalTable: "Vendors",
                        principalColumn: "VendorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReasonForRejections",
                columns: table => new
                {
                    ReasonForRejectionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusIDApprovalID = table.Column<int>(type: "int", nullable: true),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonForRejections", x => x.ReasonForRejectionID);
                    table.ForeignKey(
                        name: "FK_ReasonForRejections_approvalStatuses_StatusIDApprovalID",
                        column: x => x.StatusIDApprovalID,
                        principalTable: "approvalStatuses",
                        principalColumn: "ApprovalID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseRequests_ApprovalID1",
                table: "ExpenseRequests",
                column: "ApprovalID1");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseRequests_EmployeeID1",
                table: "ExpenseRequests",
                column: "EmployeeID1");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseRequests_VendorID1",
                table: "ExpenseRequests",
                column: "VendorID1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCodes_EventID1",
                table: "ProductCodes",
                column: "EventID1");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCodes_VendorID1",
                table: "ProductCodes",
                column: "VendorID1");

            migrationBuilder.CreateIndex(
                name: "IX_ReasonForRejections_StatusIDApprovalID",
                table: "ReasonForRejections",
                column: "StatusIDApprovalID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseItems_ExpenseRequests_ExpenseID1",
                table: "ExpenseItems",
                column: "ExpenseID1",
                principalTable: "ExpenseRequests",
                principalColumn: "ExpenseID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseRequests_approvalStatuses_ApprovalID1",
                table: "ExpenseRequests",
                column: "ApprovalID1",
                principalTable: "approvalStatuses",
                principalColumn: "ApprovalID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseRequests_Employees_EmployeeID1",
                table: "ExpenseRequests",
                column: "EmployeeID1",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseRequests_ExpenseTypes_TypeID1",
                table: "ExpenseRequests",
                column: "TypeID1",
                principalTable: "ExpenseTypes",
                principalColumn: "TypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseRequests_Vendors_VendorID1",
                table: "ExpenseRequests",
                column: "VendorID1",
                principalTable: "Vendors",
                principalColumn: "VendorID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseItems_ExpenseRequests_ExpenseID1",
                table: "ExpenseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseRequests_approvalStatuses_ApprovalID1",
                table: "ExpenseRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseRequests_Employees_EmployeeID1",
                table: "ExpenseRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseRequests_ExpenseTypes_TypeID1",
                table: "ExpenseRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseRequests_Vendors_VendorID1",
                table: "ExpenseRequests");

            migrationBuilder.DropTable(
                name: "ProductCodes");

            migrationBuilder.DropTable(
                name: "ReasonForRejections");

            migrationBuilder.DropTable(
                name: "approvalStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseItems",
                table: "ExpenseItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ExpenseRequests",
                table: "ExpenseRequests");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseRequests_ApprovalID1",
                table: "ExpenseRequests");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseRequests_EmployeeID1",
                table: "ExpenseRequests");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseRequests_VendorID1",
                table: "ExpenseRequests");

            migrationBuilder.DropColumn(
                name: "ApprovalID1",
                table: "ExpenseRequests");

            migrationBuilder.DropColumn(
                name: "EmployeeID1",
                table: "ExpenseRequests");

            migrationBuilder.DropColumn(
                name: "VendorID1",
                table: "ExpenseRequests");

            migrationBuilder.DropColumn(
                name: "totalEstimate",
                table: "ExpenseRequests");

            migrationBuilder.RenameTable(
                name: "ExpenseItems",
                newName: "expenseItems");

            migrationBuilder.RenameTable(
                name: "ExpenseRequests",
                newName: "ExpenseRequest");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseItems_ExpenseID1",
                table: "expenseItems",
                newName: "IX_expenseItems_ExpenseID1");

            migrationBuilder.RenameIndex(
                name: "IX_ExpenseRequests_TypeID1",
                table: "ExpenseRequest",
                newName: "IX_ExpenseRequest_TypeID1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_expenseItems",
                table: "expenseItems",
                column: "ExpenseItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ExpenseRequest",
                table: "ExpenseRequest",
                column: "ExpenseID");

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

            migrationBuilder.AddForeignKey(
                name: "FK_expenseItems_ExpenseRequest_ExpenseID1",
                table: "expenseItems",
                column: "ExpenseID1",
                principalTable: "ExpenseRequest",
                principalColumn: "ExpenseID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
