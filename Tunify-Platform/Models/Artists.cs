namespace Tunify_Platform.Models
{
    public class Artists
    {
        public int ID { get; set; }//PK

        public string Name { get; set; }

        public string Bio { get; set; }

        public ICollection <Songs> Songs { get; set; }//objects of songs because they are many
    }
}
