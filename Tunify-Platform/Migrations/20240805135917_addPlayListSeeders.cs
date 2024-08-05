using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class addPlayListSeeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "playlists",
                columns: new[] { "Id", "Created_Date", "Playlist_Name", "User_ID" },
                values: new object[] { 1, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "My Rock Playlist", 1 });
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
