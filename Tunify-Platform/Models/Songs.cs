namespace Tunify_Platform.Models
{
    public class Songs
    {
        public int Id { get; set; }//PK

        public string Title { get; set; }
    
        public int Artist_ID { get; set; }//FK

        public int Album_ID { get; set; }//FK
    
        public string Duration { get; set; }

        public string Gener {  get; set; }
    }
}
