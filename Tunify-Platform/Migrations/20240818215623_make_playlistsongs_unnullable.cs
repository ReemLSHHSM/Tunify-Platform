using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class make_playlistsongs_unnullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "playlists",
                columns: new[] { "Id", "Created_Date", "Playlist_Name", "UserID" },
                values: new object[] { 1, new DateTime(2024, 8, 20, 15, 30, 0, 0, DateTimeKind.Unspecified), "Chill Vibes", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "playlists",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
