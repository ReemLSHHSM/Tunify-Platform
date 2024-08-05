namespace Tunify_Platform.Models
{
    public class PlaylistSongs
    {
        public int Id { get; set; }//PR

        public int Playlist_ID { get; set; }//FK

        public int Song_ID { get; set; }//FK 
    }
}
