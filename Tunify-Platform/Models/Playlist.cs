using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Tunify_Platform.Models;

public class Playlist
{
    public int Id { get; set; } // PK

    public int UserID { get; set; } // FK

    [Required] // Example validation attribute
    public string Playlist_Name { get; set; }

    public DateTime Created_Date { get; set; }

    // The navigation property should not be required for POST unless needed
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<PlaylistSongs> PlaylistSongs { get; set; } = new List<PlaylistSongs>(); 
}
