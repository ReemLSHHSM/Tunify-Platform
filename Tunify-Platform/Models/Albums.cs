namespace Tunify_Platform.Models
{
    public class Albums
    {

        public int ID { get; set; }//PK

        public string Album_Name { get; set; }

        public DateTime Release_Date { get; set; }

        public int ArtistID { get; set; }//FK

    }
}
