namespace Tunify_Platform.Models
{
    public class PlaylistSongs
    {
       // public int Id { get; set; }//PR

        public int PlaylistID { get; set; }//FK

        public int SongID { get; set; }//FK 

        public Songs Songs { get; set; }

        public Playlist playlist { get; set; }
    }
}
