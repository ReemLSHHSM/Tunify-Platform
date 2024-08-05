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
            modelBuilder.Entity<Users>().HasData(
                new Users{
                    Id=1,
                    UserName="Reem",
                    Email="Reemlahham657@gmail.com",
                    Join_Date = new DateTime(2024, 8, 5),
                    Subscription_ID = 1
                }
                );

            modelBuilder.Entity<Songs>().HasData(
                new Songs
                {
                    Id = 1,
                    Title = "Song One",
                    Artist_ID = 1,
                    Album_ID = 1,
                    Duration = "3:45",
                    Gener = "Rock"
                }
                );

            modelBuilder.Entity<Playlist>().HasData(
                new Playlist
                {
                    Id = 1,
                    User_ID = 1, // FK value
                    Playlist_Name = "My Rock Playlist",
                    Created_Date = new DateTime(2024, 8, 5)
                }
                );
        }
      
    }
}

