using Microsoft.EntityFrameworkCore.Migrations;

namespace EPIWalletAPI.Migrations
{
    public partial class banking_details_and_account_type : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accountType",
                columns: table => new
                {
                    AccountTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accountType", x => x.AccountTypeID);
                });

            migrationBuilder.CreateTable(
                name: "employeeBankingDetails",
                columns: table => new
                {
                    BankingDetailsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountTypeID = table.Column<int>(type: "int", nullable: false),
                    EmployeeID = table.Column<int>(type: "int", nullable: false),
                    AccountNunmber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Bank = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employeeBankingDetails", x => x.BankingDetailsID);
                    table.ForeignKey(
                        name: "FK_employeeBankingDetails_accountType_AccountTypeID",
                        column: x => x.AccountTypeID,
                        principalTable: "accountType",
                        principalColumn: "AccountTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_employeeBankingDetails_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employeeBankingDetails_AccountTypeID",
                table: "employeeBankingDetails",
                column: "AccountTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_employeeBankingDetails_EmployeeID",
                table: "employeeBankingDetails",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employeeBankingDetails");

            migrationBuilder.DropTable(
                name: "accountType");
        }
    }
}
