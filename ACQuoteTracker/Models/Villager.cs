using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ACQuoteTracker.Models
{
    public class Villager
    {
        public int VillagerId { get; set; }
        public string name { get; set; }
        
        [UrlAttribute]
        public string ImageUrl { get; set; }
        
        public List<Quote> Quotes { get; set; }
        
    }
}