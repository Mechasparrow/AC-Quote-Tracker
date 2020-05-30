using System.Collections;
using System.Collections.Generic;
using ACQuoteTracker.Data;
using ACQuoteTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ACQuoteTracker.Controllers
{
    public class QuotesController : Controller
    {

        private readonly IQuoteData _quoteData;
        
        
        public QuotesController(IQuoteData quoteData)
        {
            this._quoteData = quoteData;
        }
        
        public IEnumerable<Quote> Quotes { get; set; }
        
        // GET
        public IActionResult Index()
        {
            Quotes = this._quoteData.GetQuotes();
            return View(Quotes);
        }
    }
}