using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemMonitoringAPI.Migrations
{
    /// <inheritdoc />
    public partial class ArchiveCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeletedTransactions",
                columns: table => new
                {
                    DelTransID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DateDeleted = table.Column<DateOnly>(type: "date", nullable: true),
                    BorrowDate = table.Column<DateOnly>(type: "date", nullable: true),
                    BrwCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrwName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DprName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemCode = table.Column<int>(type: "int", nullable: false),
                    ItemName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransactionsTransID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeletedTransactions", x => x.DelTransID);
                    table.ForeignKey(
                        name: "FK_DeletedTransactions_Transactions_TransactionsTransID",
                        column: x => x.TransactionsTransID,
                        principalTable: "Transactions",
                        principalColumn: "TransID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeletedTransactions_TransactionsTransID",
                table: "DeletedTransactions",
                column: "TransactionsTransID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeletedTransactions");
        }
    }
}
