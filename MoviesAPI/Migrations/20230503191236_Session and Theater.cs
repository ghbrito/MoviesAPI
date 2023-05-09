using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoviesAPI.Migrations
{
    /// <inheritdoc />
    public partial class SessionandTheater : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TheaterId",
                table: "Sessions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_TheaterId",
                table: "Sessions",
                column: "TheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Theaters_TheaterId",
                table: "Sessions",
                column: "TheaterId",
                principalTable: "Theaters",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Theaters_TheaterId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_TheaterId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "TheaterId",
                table: "Sessions");
        }
    }
}
