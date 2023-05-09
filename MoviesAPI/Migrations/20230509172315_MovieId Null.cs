using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesAPI.Migrations
{
    /// <inheritdoc />
    public partial class MovieIdNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Movies_MovieID",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Movies_movieId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Movies_MovieID",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieID",
                table: "Movies");

            migrationBuilder.AlterColumn<int>(
                name: "movieId",
                table: "Sessions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Movies_movieId",
                table: "Sessions",
                column: "movieId",
                principalTable: "Movies",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Movies_movieId",
                table: "Sessions");

            migrationBuilder.AlterColumn<int>(
                name: "movieId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieID",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_MovieID",
                table: "Movies",
                column: "MovieID");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Movies_MovieID",
                table: "Movies",
                column: "MovieID",
                principalTable: "Movies",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Movies_movieId",
                table: "Sessions",
                column: "movieId",
                principalTable: "Movies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
