using System.Collections;
using System.Collections.Generic;
using ACQuoteTracker.Models;

namespace ACQuoteTracker.Data
{
    public interface IQuoteData
    {
        public IEnumerable<Quote> GetQuotes();
        public Quote FindById(int ID);
        public Quote AddQuote(Quote newQuote);
        
    }
}