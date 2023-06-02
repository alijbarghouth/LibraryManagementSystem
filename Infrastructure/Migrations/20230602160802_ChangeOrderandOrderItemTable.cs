using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrderandOrderItemTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateRetrive",
                table: "OrderItems");

            migrationBuilder.RenameColumn(
                name: "ReturnedDate",
                table: "OrderItems",
                newName: "DateRetrieved");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateRetrieved",
                table: "OrderItems",
                newName: "ReturnedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateRetrive",
                table: "OrderItems",
                type: "datetime2",
                nullable: true);
        }
    }
}
