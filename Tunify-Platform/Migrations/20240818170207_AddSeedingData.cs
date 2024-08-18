using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "albums",
                columns: new[] { "ID", "Album_Name", "ArtistID", "Release_Date" },
                values: new object[] { 1, "Album One", 1, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "artists",
                columns: new[] { "ID", "Bio", "Name" },
                values: new object[] { 1, "A popular artist", "Artist One" });

            migrationBuilder.InsertData(
                table: "songs",
                columns: new[] { "Id", "AlbumID", "ArtistID", "Duration", "Gener", "Title" },
                values: new object[] { 1, 1, 1, "3:45", "Rock", "Song One" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "albums",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "artists",
                keyColumn: "ID",
                keyValue: 1);
        }
    }
}
