using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repository.Interfaces;

namespace Tunify_Platform.Repository.Services
{
    public class SongsServices:ISongs
    {
        public readonly TunifyDBContext _context;

        public SongsServices(TunifyDBContext tunifyDBContext)
        {
            _context = tunifyDBContext;
        }

        public async Task<Songs> AddSongs(Songs song)
        {
            _context.songs.Add(song);
            _context.SaveChanges();
            return song;
        }

        public async Task<Songs> DeleteUser(int id)
        {
           var data=await getSongs(id);
            _context.Remove(data);
            _context.SaveChanges();
            return null;
        }

        public async Task<List<Songs>> getAllSongs()
        {
          return _context.songs.ToList();
        }

        public async Task<Songs> getSongs(int id)
        {
            var data = _context.songs.FindAsync(id);
            return await data;
        }

        public async Task<Songs> UpdateSongs(Songs song, int id)
        {
            var existingSong=await getSongs(id);
            existingSong = song;
            _context.SaveChanges();
            return existingSong;
        }

       

        public async Task<List<Songs>> getAllSongsFromPlaylist(int playlistId)
        {
            return await _context.playlistSongs
            .Where(ps => ps.PlaylistID == playlistId)
            .Select(ps => ps.Songs)
            .ToListAsync();
            
           
        }

        public async Task<List<Songs>> getAllSongsFromArtist(int artistID)
        {
            return await _context.songs.Where(
                s => s.ArtistID == artistID)
                .ToListAsync();
        }
    }
}

