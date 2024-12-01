using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemMonitoringAPI.Migrations
{
    /// <inheritdoc />
    public partial class transactionFieldReqFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_BrwCode",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BrwCode",
                table: "Transactions",
                column: "BrwCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Transactions_BrwCode",
                table: "Transactions");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BrwCode",
                table: "Transactions",
                column: "BrwCode",
                unique: true);
        }
    }
}
