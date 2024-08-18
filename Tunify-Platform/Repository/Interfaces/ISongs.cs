using Tunify_Platform.Models;

namespace Tunify_Platform.Repository.Interfaces
{
    public interface ISongs
    {
        Task<List<Songs>> getAllSongs();

        Task<Songs> getSongs(int id);

        Task<Songs> AddSongs(Songs song);

        Task<Songs> UpdateSongs(Songs song, int id);

        Task<Songs> DeleteUser(int id);

        Task<PlaylistSongs> addToPlaylist(int songID,int playlistID);
    }
}
