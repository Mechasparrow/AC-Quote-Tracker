using System.ComponentModel.DataAnnotations;

namespace ACQuoteTracker.Models
{
    public class Quote
    {
        public int ID { get; set; }
        
        public int VillagerId { get; set; }
        public Villager Villager { get; set; }

        public string QuoteText { get; set; }
        
        
    }
}