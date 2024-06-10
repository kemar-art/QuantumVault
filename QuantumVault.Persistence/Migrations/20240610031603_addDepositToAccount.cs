using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuantumVault.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addDepositToAccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Deposit",
                table: "Accounts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deposit",
                table: "Accounts");
        }
    }
}
