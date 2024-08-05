namespace Tunify_Platform.Models
{
    public class Subscriptions
    {
       public int Id { get; set; }//PK

        public string SubscriptionType { get; set; }
        public double Price {  get; set; }    
    }
}
