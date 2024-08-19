using Microsoft.EntityFrameworkCore;
using Tunify_Platform.Data;
using Tunify_Platform.Models;
using Tunify_Platform.Repository.Interfaces;

namespace Tunify_Platform.Repository.Services
{
    public class ArtistsServices : IArtists
    {
        public readonly TunifyDBContext _context;

        public ArtistsServices(TunifyDBContext tunifyDBContext)
        {
            _context = tunifyDBContext;
        }

        public async Task<Artists> AddArtists(Artists artist)
        {
             _context.artists.Add(artist);
            _context.SaveChanges();
            return artist;
        }

        public async Task<Artists> DeleteUser(int id)
        {
           var data=await getArtists(id);
            _context.artists.Remove(data);
            _context.SaveChanges();
            return null;
        }

        public async Task<List<Artists>> getAllArtists()
        {
            return await _context.artists.ToListAsync();//here artists is the name of the dbset made for the Artists model
        }

        public async Task<Artists> getArtists(int id)
        {
           var data=await _context.artists.FindAsync(id);
            return data;
        }

        public async Task<Artists> UpdateArtists(Artists artist, int id)
        {
            var existingArtist = await getArtists(id);
            existingArtist = artist;
             _context.SaveChanges();
            return existingArtist;
        }

        public async Task<Songs> AddSongToArtist(int songID, int artistID)
        {
            var song = await _context.songs.FindAsync(songID);
            song.ArtistID = artistID;
            _context.songs.Update(song);
            await _context.SaveChangesAsync();

            return song;
        }
    }
}
