using System.Text.Json.Serialization;

namespace Tunify_Platform.Models
{
    public class PlaylistSongs
    {
       // public int Id { get; set; }//PR

        public int PlaylistID { get; set; }//FK

        public int SongID { get; set; }//FK 

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Songs Songs { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Playlist playlist { get; set; }
    }
}
