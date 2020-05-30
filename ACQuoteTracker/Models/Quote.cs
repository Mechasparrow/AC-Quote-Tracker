using System.ComponentModel.DataAnnotations;

namespace ACQuoteTracker.Models
{
    public class Quote
    {
        public int ID { get; set; }
        
        public string VillagerName { get; set; }
        
        public string QuoteText { get; set; }
        
        [UrlAttribute]
        public string ImageUrl { get; set; }
    }
}