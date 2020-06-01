using System.Collections.Generic;
using ACQuoteTracker.Models;
using System.Linq;

namespace ACQuoteTracker.Data
{
    public class InMemoryQuoteStore : IQuoteData
    {
        private List<Quote> quotes;
        private IVillagerData _villagerData;
        
        public InMemoryQuoteStore(IVillagerData villagerData)
        {
            this._villagerData = villagerData;
            quotes = new List<Quote>()
            {
                new Quote{ID = 1,QuoteText = "All that glitters is not gold", VillagerId = 11, Villager = _villagerData.FindById(11)},
                new Quote{ID = 2,QuoteText = "meh", VillagerId= 122,Villager = _villagerData.FindById(122)},
                new Quote{ID = 3,QuoteText = "meh", VillagerId= 352,Villager = _villagerData.FindById(352)}
            };
        }
        
        public IEnumerable<Quote> GetQuotes()
        {
            return quotes;
        }

        public Quote FindById(int ID)
        {
            var quote = quotes.SingleOrDefault(q => q.ID == ID);
            return quote;
        }

        public Quote AddQuote(Quote newQuote)
        {
            newQuote.ID = quotes.Max(q => q.ID) + 1;
            quotes.Add(newQuote);
            return newQuote;
        }
    }
}