using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repository.Interfaces;

namespace Tunify_Platform.Repository.Services
{
    public class PlaylistServices : IPlaylist
    {
        public readonly TunifyDBContext _context;
        public PlaylistServices(TunifyDBContext context)
        {
            _context = context;
        }

        public async Task<Playlist> AddPlaylist(Playlist list)
        {
            // Ensure no issues with null navigation properties
            if (list.PlaylistSongs == null)
            {
                list.PlaylistSongs = new List<PlaylistSongs>();
            }

            _context.playlists.Add(list);
            await _context.SaveChangesAsync();
            return list;
        }


        public async Task<Playlist> DeleteUser(int id)
        {
            var playlist=await getPlaylist(id);
            _context.playlists.Remove(playlist);
            _context.SaveChanges();
            return null;
        }

        public async Task<List<Playlist>> getAllPlaylist()
        {
          return _context.playlists.ToList();
        }

        public async Task<Playlist> getPlaylist(int id)
        {
            var playlist = await _context.playlists.FindAsync(id);
                //.Include(p => p.PlaylistSongs) // Include related PlaylistSongs
                //.ThenInclude(ps => ps.Songs)    // Optionally include Songs if needed
                //.FirstOrDefaultAsync(p => p.Id == id);

            return playlist;
        }

        public async Task<PlaylistSongs> addToPlaylist(int playlistId, int songId)
        {
            var playlistsong = new PlaylistSongs();
            playlistsong.PlaylistID = playlistId;
            playlistsong.SongID = songId;

            _context.playlistSongs.Add(playlistsong);
            await _context.SaveChangesAsync();
            return playlistsong;
        }


        public async Task<Playlist> UpdatePlaylist(Playlist list, int id)
        {
            var existingplaylist = await getPlaylist(id);
            existingplaylist = list;
          _context.SaveChanges();
            return existingplaylist;

        }
    }
}
