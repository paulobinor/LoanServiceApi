using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LoanServiceApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitializeCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    LoanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanAmount = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MonthlyRepaymentAmount = table.Column<double>(type: "float", nullable: false),
                    AmountPaid = table.Column<double>(type: "float", nullable: false),
                    BalanceDue = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.LoanId);
                });

            migrationBuilder.CreateTable(
                name: "LoanRepayments",
                columns: table => new
                {
                    LoanRepaymentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoanId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AmountPaid = table.Column<double>(type: "float", nullable: false),
                    DatePaid = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRepayments", x => x.LoanRepaymentId);
                    table.ForeignKey(
                        name: "FK_LoanRepayments_Loans_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loans",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "LoanId", "AmountPaid", "BalanceDue", "CustomerNo", "EndDate", "LoanAmount", "LoanName", "MonthlyRepaymentAmount", "StartDate" },
                values: new object[,]
                {
                    { "b5e2a007-0903-448f-9b2e-55cddc0d6fb7", 6000.0, 14000.0, "C002", new DateTime(2026, 5, 11, 10, 1, 57, 410, DateTimeKind.Local).AddTicks(2344), 20000.0, "Car Loan", 1000.0, new DateTime(2024, 5, 11, 10, 1, 57, 410, DateTimeKind.Local).AddTicks(2343) },
                    { "cc4fcb00-9f3d-4a4f-ae26-12d4fe2a665e", 1500.0, 8500.0, "C001", new DateTime(2025, 8, 11, 10, 1, 57, 410, DateTimeKind.Local).AddTicks(2334), 10000.0, "Personal Loan", 500.0, new DateTime(2024, 8, 11, 10, 1, 57, 410, DateTimeKind.Local).AddTicks(2311) }
                });

            migrationBuilder.InsertData(
                table: "LoanRepayments",
                columns: new[] { "LoanRepaymentId", "AmountPaid", "DatePaid", "LoanId" },
                values: new object[,]
                {
                    { "8ec20728-5e6b-4e33-a80f-8d0cbc374261", 500.0, new DateTime(2024, 9, 11, 10, 1, 57, 410, DateTimeKind.Local).AddTicks(2465), "cc4fcb00-9f3d-4a4f-ae26-12d4fe2a665e" },
                    { "f52deed2-8769-46ef-9646-dc1d02767203", 1000.0, new DateTime(2024, 10, 11, 10, 1, 57, 410, DateTimeKind.Local).AddTicks(2479), "b5e2a007-0903-448f-9b2e-55cddc0d6fb7" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanRepayments_LoanId",
                table: "LoanRepayments",
                column: "LoanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanRepayments");

            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
