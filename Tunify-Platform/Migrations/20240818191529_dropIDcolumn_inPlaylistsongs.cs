using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tunify_Platform.Migrations
{
    /// <inheritdoc />
    public partial class dropIDcolumn_inPlaylistsongs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_playlistSongs",
                table: "playlistSongs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "playlistSongs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_playlistSongs",
                table: "playlistSongs",
                columns: new[] { "PlaylistID", "SongID" });

            migrationBuilder.CreateIndex(
                name: "IX_playlistSongs_SongID",
                table: "playlistSongs",
                column: "SongID");

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_playlists_PlaylistID",
                table: "playlistSongs",
                column: "PlaylistID",
                principalTable: "playlists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_playlistSongs_songs_SongID",
                table: "playlistSongs",
                column: "SongID",
                principalTable: "songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_playlists_PlaylistID",
                table: "playlistSongs");

            migrationBuilder.DropForeignKey(
                name: "FK_playlistSongs_songs_SongID",
                table: "playlistSongs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_playlistSongs",
                table: "playlistSongs");

            migrationBuilder.DropIndex(
                name: "IX_playlistSongs_SongID",
                table: "playlistSongs");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "playlistSongs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_playlistSongs",
                table: "playlistSongs",
                column: "Id");
        }
    }
}
