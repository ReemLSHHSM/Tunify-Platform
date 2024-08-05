using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class addSongssSeeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "songs",
                columns: new[] { "Id", "Album_ID", "Artist_ID", "Duration", "Gener", "Title" },
                values: new object[] { 1, 1, 1, "3:45", "Rock", "Song One" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
