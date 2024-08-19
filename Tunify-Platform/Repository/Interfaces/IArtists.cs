using Tunify_Platform.Models;

namespace Tunify_Platform.Repository.Interfaces
{
    public interface IArtists
    {
        Task<List<Artists>> getAllArtists();

        Task<Artists> getArtists(int id);

        Task<Artists> AddArtists(Artists artist);

        Task<Artists> UpdateArtists(Artists artist, int id);

        Task<Artists> DeleteUser(int id);
        Task<Songs> AddSongToArtist(int songID, int artistID);
    }
}
