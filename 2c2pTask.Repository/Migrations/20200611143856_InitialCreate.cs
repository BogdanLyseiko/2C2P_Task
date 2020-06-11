using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace _2c2pTask.Repository.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    CurrencyCode = table.Column<string>(maxLength: 3, nullable: false),
                    TransactionDate = table.Column<DateTime>(nullable: false),
                    StatusID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Transactions_Statuses_StatusID",
                        column: x => x.StatusID,
                        principalTable: "Statuses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "ID", "Name" },
                values: new object[] { 1, "Approved" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "ID", "Name" },
                values: new object[] { 2, "Rejected" });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "ID", "Name" },
                values: new object[] { 3, "Done" });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_StatusID",
                table: "Transactions",
                column: "StatusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
