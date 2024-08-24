using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;

namespace Tunify_Platform.Data
{
    public class TunifyDBContext : IdentityDbContext<IdentityUser>
    {
        public TunifyDBContext(DbContextOptions<TunifyDBContext> options) : base(options)
        {

        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Subscriptions> subscriptions { get; set; }

        public DbSet<Songs> songs { get; set; }
        public DbSet<PlaylistSongs> playlistSongs { get; set; }
        public DbSet<Playlist> playlists { get; set; }
        public DbSet<Artists> artists { get; set; }
        public DbSet<Albums> albums { get; set; }

        //seed initial data for User and Song and Playlist.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        //when overriding any method it has to have the same type of access modifire
        {
            base.OnModelCreating(modelBuilder);//to ensure that any configurations provided by the base class are applied.
            //Creating relation between songs and artist

            modelBuilder.Entity<Artists>().
            HasMany(a => a.Songs).
            WithOne(a => a.Artist).
            HasForeignKey(a => a.ArtistID);
            //.IsRequired(); to specify that this shall not be null

            modelBuilder.Entity<Songs>().
            HasOne(s => s.Artist).
            WithMany(s => s.Songs).
            HasForeignKey(s => s.ArtistID);

            //Adding composit key to playlistsongs
            modelBuilder.Entity<PlaylistSongs>()
            .HasKey(ps => new { ps.PlaylistID, ps.SongID });

            //creating relation between playlistsong and song
            modelBuilder.Entity<PlaylistSongs>().
            HasOne(p => p.Songs).
            WithMany(p => p.PlaylistsSongs).
            HasForeignKey(p => p.SongID);

            //Creating relation between playlistsong and playlist
            modelBuilder.Entity<PlaylistSongs>().
            HasOne(p => p.playlist).
            WithMany(p => p.PlaylistSongs).
            HasForeignKey(p => p.PlaylistID);



            modelBuilder.Entity<Subscriptions>().HasData(
        new Subscriptions
        {
            Id = 1,
            SubscriptionType = "Premium",
            Price = 9.99
        }
    );

            modelBuilder.Entity<Artists>().HasData(
                new Artists
                {
                    ID = 1,
                    Name = "Artist One",
                    Bio = "A popular artist"
                }
            );

            modelBuilder.Entity<Albums>().HasData(
                new Albums
                {
                    ID = 1,
                    Album_Name = "Album One",
                    Release_Date = new DateTime(2024, 8, 5),
                    ArtistID = 1
                }
            );

            modelBuilder.Entity<Songs>().HasData(
                new Songs
                {
                    Id = 1,
                    Title = "Song One",
                    ArtistID = 1,
                    AlbumID = 1,
                    Duration = "3:45",
                    Gener = "Rock"
                }
            );

            modelBuilder.Entity<Playlist>().HasData(
                new Playlist
                {
                    Id = 1,
                    UserID = 1,
                    Playlist_Name = "Chill Vibes",
                    Created_Date = new DateTime(2024, 8, 20, 15, 30, 0)
                }
            );

            modelBuilder.Entity<Users>().HasData(
                new Users
                {
                    Id = 1,
                    UserName = "user1",
                    Email = "user1@example.com",
                    Join_Date = new DateTime(2024, 8, 1),
                    SubscriptionID = 1
                }
            );

            modelBuilder.Entity<PlaylistSongs>().HasData(
                new PlaylistSongs
                {
                    PlaylistID = 1,
                    SongID = 1
                }
            );
        }
    }
}

