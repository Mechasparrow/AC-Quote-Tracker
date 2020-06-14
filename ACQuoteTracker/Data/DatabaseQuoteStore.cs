using System.Collections.Generic;
using System.Linq;
using ACQuoteTracker.Models;

namespace ACQuoteTracker.Data
{
    public class DatabaseQuoteStore : IQuoteData
    {
        private readonly QuoteTrackerDbContext _context;

        public DatabaseQuoteStore(QuoteTrackerDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Quote> GetQuotes()
        {
            return _context.Quotes;
        }

        public Quote FindById(int ID)
        {
            return _context.Quotes.FirstOrDefault(q => q.QuoteId == ID);
        }

        public Quote AddQuote(Quote newQuote)
        {
            newQuote.Villager = _context.Villagers.FirstOrDefault(v => v.VillagerId == newQuote.VillagerId);
            var quoteEntry = _context.Quotes.Add(newQuote);
            return quoteEntry.Entity;
        }

        public Quote DeleteQuote(Quote quoteToDelete)
        {
            var deletedQuoteEntry = _context.Quotes.Remove(quoteToDelete);
            return deletedQuoteEntry.Entity;
        }

        public void CommitChanges()
        {
            _context.SaveChanges();
        }
    }
}