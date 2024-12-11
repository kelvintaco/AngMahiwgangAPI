using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemMonitoringAPI.Migrations
{
    /// <inheritdoc />
    public partial class DeletedUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeletedTransactions_Transactions_TransactionsTransID",
                table: "DeletedTransactions");

            migrationBuilder.DropIndex(
                name: "IX_DeletedTransactions_TransactionsTransID",
                table: "DeletedTransactions");

            migrationBuilder.DropColumn(
                name: "TransactionsTransID",
                table: "DeletedTransactions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TransactionsTransID",
                table: "DeletedTransactions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DeletedTransactions_TransactionsTransID",
                table: "DeletedTransactions",
                column: "TransactionsTransID");

            migrationBuilder.AddForeignKey(
                name: "FK_DeletedTransactions_Transactions_TransactionsTransID",
                table: "DeletedTransactions",
                column: "TransactionsTransID",
                principalTable: "Transactions",
                principalColumn: "TransID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
