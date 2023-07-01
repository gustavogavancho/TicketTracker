using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketTracker.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ExpenseTypeColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ExpenseType",
                table: "Ticket",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpenseType",
                table: "Ticket");
        }
    }
}
