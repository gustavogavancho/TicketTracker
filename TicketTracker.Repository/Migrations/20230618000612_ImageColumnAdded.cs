using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketTracker.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ImageColumnAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketAttached",
                table: "Ticket");

            migrationBuilder.AlterColumn<long>(
                name: "Nit",
                table: "Ticket",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Ticket",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Ticket",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Ticket");

            migrationBuilder.AlterColumn<long>(
                name: "Nit",
                table: "Ticket",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "Ticket",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "TicketAttached",
                table: "Ticket",
                type: "BLOB",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
