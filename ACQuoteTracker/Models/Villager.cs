using System.ComponentModel.DataAnnotations;

namespace ACQuoteTracker.Models
{
    public class Villager
    {
        public int ID { get; set; }
        public string name { get; set; }
        
        [UrlAttribute]
        public string ImageUrl { get; set; }
    }
}