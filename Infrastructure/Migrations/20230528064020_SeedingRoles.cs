using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "RoleName" },
                values: new object[] { Guid.NewGuid().ToString(), "Patrons" }
             );

            migrationBuilder.InsertData(
                   table: "Roles",
                   columns: new[] { "Id", "RoleName" },
                   values: new object[] { Guid.NewGuid().ToString(), "Librarians" }
                );
            migrationBuilder.InsertData(
                   table: "Roles",
                   columns: new[] { "Id", "RoleName" },
                   values: new object[] { Guid.NewGuid().ToString(), "Administrators" }
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [Roles]");
        }
    }
}
