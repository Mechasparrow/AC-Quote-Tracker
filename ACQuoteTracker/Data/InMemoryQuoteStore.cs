using System.Collections.Generic;
using ACQuoteTracker.Models;
using System.Linq;

namespace ACQuoteTracker.Data
{
    public class InMemoryQuoteStore : IQuoteData
    {
        private List<Quote> quotes;

        public InMemoryQuoteStore()
        {
            quotes = new List<Quote>()
            {
                new Quote{ID = 1,QuoteText = "meh", VillagerName = "Thomson",ImageUrl = "https://vignette.wikia.nocookie.net/animalcrossing/images/2/2a/Raymond_NH.png/revision/latest?cb=20200317174731"},
                new Quote{ID = 2,QuoteText = "meh", VillagerName = "Ribbit",ImageUrl = "https://vignette.wikia.nocookie.net/animalcrossing/images/2/2a/Raymond_NH.png/revision/latest?cb=20200317174731"},
                new Quote{ID = 3,QuoteText = "meh", VillagerName = "Raymond", ImageUrl = "https://vignette.wikia.nocookie.net/animalcrossing/images/2/2a/Raymond_NH.png/revision/latest?cb=20200317174731"}
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