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
          _context.playlists.Add(list);
            _context.SaveChanges();
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
            var data=await _context.playlists.FindAsync(id);
            return data;
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
