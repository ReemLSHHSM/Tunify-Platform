using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "playlists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "songs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Subscription_ID",
                table: "Users",
                newName: "SubscriptionID");

            migrationBuilder.RenameColumn(
                name: "Artist_ID",
                table: "songs",
                newName: "ArtistID");

            migrationBuilder.RenameColumn(
                name: "Album_ID",
                table: "songs",
                newName: "AlbumID");

            migrationBuilder.RenameColumn(
                name: "Song_ID",
                table: "playlistSongs",
                newName: "SongID");

            migrationBuilder.RenameColumn(
                name: "Playlist_ID",
                table: "playlistSongs",
                newName: "PlaylistID");

            migrationBuilder.RenameColumn(
                name: "User_ID",
                table: "playlists",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "Artist_ID",
                table: "albums",
                newName: "ArtistID");

            migrationBuilder.CreateIndex(
                name: "IX_songs_ArtistID",
                table: "songs",
                column: "ArtistID");

            migrationBuilder.AddForeignKey(
                name: "FK_songs_artists_ArtistID",
                table: "songs",
                column: "ArtistID",
                principalTable: "artists",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_songs_artists_ArtistID",
                table: "songs");

            migrationBuilder.DropIndex(
                name: "IX_songs_ArtistID",
                table: "songs");

            migrationBuilder.RenameColumn(
                name: "SubscriptionID",
                table: "Users",
                newName: "Subscription_ID");

            migrationBuilder.RenameColumn(
                name: "ArtistID",
                table: "songs",
                newName: "Artist_ID");

            migrationBuilder.RenameColumn(
                name: "AlbumID",
                table: "songs",
                newName: "Album_ID");

            migrationBuilder.RenameColumn(
                name: "SongID",
                table: "playlistSongs",
                newName: "Song_ID");

            migrationBuilder.RenameColumn(
                name: "PlaylistID",
                table: "playlistSongs",
                newName: "Playlist_ID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "playlists",
                newName: "User_ID");

            migrationBuilder.RenameColumn(
                name: "ArtistID",
                table: "albums",
                newName: "Artist_ID");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Join_Date", "Subscription_ID", "UserName" },
                values: new object[] { 1, "Reemlahham657@gmail.com", new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Reem" });

            migrationBuilder.InsertData(
                table: "playlists",
                columns: new[] { "Id", "Created_Date", "Playlist_Name", "User_ID" },
                values: new object[] { 1, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "My Rock Playlist", 1 });

            migrationBuilder.InsertData(
                table: "songs",
                columns: new[] { "Id", "Album_ID", "Artist_ID", "Duration", "Gener", "Title" },
                values: new object[] { 1, 1, 1, "3:45", "Rock", "Song One" });
        }
    }
}
