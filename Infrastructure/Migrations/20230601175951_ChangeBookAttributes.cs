using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBookAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRequest",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "RequestDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRetrive",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowingDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookStatus",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowingDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "BookStatus",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "Orders",
                newName: "OrderDate");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateRetrive",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRequest",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Availability",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
