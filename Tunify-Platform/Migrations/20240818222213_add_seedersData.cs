using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class add_seedersData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Join_Date", "SubscriptionID", "UserName" },
                values: new object[] { 1, "user1@example.com", new DateTime(2024, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "user1" });

            migrationBuilder.InsertData(
                table: "playlistSongs",
                columns: new[] { "PlaylistID", "SongID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "subscriptions",
                columns: new[] { "Id", "Price", "SubscriptionType" },
                values: new object[] { 1, 9.9900000000000002, "Premium" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "playlistSongs",
                keyColumns: new[] { "PlaylistID", "SongID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "subscriptions",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
