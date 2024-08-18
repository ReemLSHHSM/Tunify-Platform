using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Models;

namespace Tunify_Platform.Data
{
    public class TunifyDBContext : DbContext
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
            HasOne(p=>p.Songs).
            WithMany(p=>p.PlaylistsSongs).
            HasForeignKey(p=>p.SongID);

            //Creating relation between playlistsong and playlist
            modelBuilder.Entity<PlaylistSongs>().
            HasOne(p=>p.playlist).
            WithMany(p=>p.playlistSongs).
            HasForeignKey(p=> p.PlaylistID);



            modelBuilder.Entity<Artists>().HasData(
         new Artists
         {
             ID = 1, // Ensure this matches the ArtistID used in the Songs seed data
             Name = "Artist One",
             Bio = "A popular artist"
         }
 
     );


            modelBuilder.Entity<Albums>().HasData(
        new Albums
        {
            ID = 1, // Ensure this matches the AlbumID used in the Songs seed data
            Album_Name = "Album One",
            Release_Date = new DateTime(2024, 8, 5),
            ArtistID = 1 // Valid Artist ID
        }
    );
            modelBuilder.Entity<Songs>().HasData(
        new Songs
        {
            Id = 1,
            Title = "Song One",
            ArtistID = 1, // Valid Artist ID
            AlbumID = 1,  // Valid Album ID
            Duration = "3:45",
            Gener = "Rock"
        }
            );
        }
      
    }
}

