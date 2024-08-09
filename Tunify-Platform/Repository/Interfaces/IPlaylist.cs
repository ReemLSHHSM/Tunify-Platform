using Tunify_Platform.Models;

namespace Tunify_Platform.Repository.Interfaces
{
    public interface IPlaylist
    {
        Task<List<Playlist>> getAllPlaylist();

        Task<Playlist> getPlaylist(int id);

        Task<Playlist> AddPlaylist(Playlist list);

        Task<Playlist> UpdatePlaylist(Playlist list, int id);

        Task<Playlist> DeleteUser(int id);
    }
}
