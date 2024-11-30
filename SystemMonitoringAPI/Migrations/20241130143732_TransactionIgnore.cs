using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemMonitoringAPI.Migrations
{
    /// <inheritdoc />
    public partial class TransactionIgnore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_ItemCode",
                table: "Transactions");

            migrationBuilder.AddColumn<string>(
                name: "TransactionsTransID",
                table: "Items",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ItemCode",
                table: "Transactions",
                column: "ItemCode");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TransactionsTransID",
                table: "Items",
                column: "TransactionsTransID");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Transactions_TransactionsTransID",
                table: "Items",
                column: "TransactionsTransID",
                principalTable: "Transactions",
                principalColumn: "TransID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Transactions_TransactionsTransID",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ItemCode",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Items_TransactionsTransID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "TransactionsTransID",
                table: "Items");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ItemCode",
                table: "Transactions",
                column: "ItemCode",
                unique: true);
        }
    }
}
