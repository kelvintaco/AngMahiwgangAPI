using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SystemMonitoringAPI.Migrations
{
    /// <inheritdoc />
    public partial class TransactionModelFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BrwName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DprName",
                table: "Transactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ItemName",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BrwName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "DprName",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Transactions");
        }
    }
}
