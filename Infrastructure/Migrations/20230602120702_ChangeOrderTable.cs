using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowingDate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateRetrive",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "Orders",
                newName: "OrderDate");

            migrationBuilder.RenameColumn(
                name: "ReturnedAt",
                table: "OrderItems",
                newName: "ReturnedDate");

            migrationBuilder.RenameColumn(
                name: "BorrowedAt",
                table: "OrderItems",
                newName: "RequestDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowedDate",
                table: "OrderItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRetrive",
                table: "OrderItems",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowedDate",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "DateRetrive",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "OrderDate",
                table: "Orders",
                newName: "RequestDate");

            migrationBuilder.RenameColumn(
                name: "ReturnedDate",
                table: "OrderItems",
                newName: "ReturnedAt");

            migrationBuilder.RenameColumn(
                name: "RequestDate",
                table: "OrderItems",
                newName: "BorrowedAt");

            migrationBuilder.AddColumn<DateTime>(
                name: "BorrowingDate",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRetrive",
                table: "Orders",
                type: "datetime2",
                nullable: true);
        }
    }
}
