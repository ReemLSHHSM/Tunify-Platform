namespace Tunify_Platform.Models
{
    public class Songs
    {
        public int Id { get; set; }//PK

        public string Title { get; set; }
    
        public int ArtistID { get; set; }//FK

        public int AlbumID { get; set; }//FK
    
        public string Duration { get; set; }

        public string Gener {  get; set; }

        public Artists Artist { get; set; }//one artist because 1 singer to many songs

        public ICollection<PlaylistSongs> PlaylistsSongs { get; set; }
    }
}
