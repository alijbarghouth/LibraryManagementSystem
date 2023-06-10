using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_Genres_GenreId",
                table: "BookGenre");

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "BookGenre",
                newName: "GenresId");

            migrationBuilder.RenameIndex(
                name: "IX_BookGenre_GenreId",
                table: "BookGenre",
                newName: "IX_BookGenre_GenresId");

            migrationBuilder.AddColumn<double>(
                name: "AverageRating",
                table: "Books",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_Genres_GenresId",
                table: "BookGenre",
                column: "GenresId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGenre_Genres_GenresId",
                table: "BookGenre");

            migrationBuilder.DropColumn(
                name: "AverageRating",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "GenresId",
                table: "BookGenre",
                newName: "GenreId");

            migrationBuilder.RenameIndex(
                name: "IX_BookGenre_GenresId",
                table: "BookGenre",
                newName: "IX_BookGenre_GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGenre_Genres_GenreId",
                table: "BookGenre",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
