using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using ACQuoteTracker.Data;
using ACQuoteTracker.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace ACQuoteTracker.Controllers
{
    public class QuotesController : Controller
    {

        private readonly IQuoteData _quoteData;
        private readonly IVillagerData _villagerData;
        
        public QuotesController(IQuoteData quoteData, IVillagerData villagerData)
        {
            this._quoteData = quoteData;
            this._villagerData = villagerData;
        }
        
        public IEnumerable<Quote> Quotes { get; set; }
        
        // GET
        public IActionResult Index()
        {
            Quotes = this._quoteData.GetQuotes();
            ViewBag.Villagers = this._villagerData.GetVillagers().ToList();
            return View(Quotes);
        }
        
        //  Post
        public IActionResult Create()
        {
            Quote q = new Quote();
            ViewBag.Villagers = this._villagerData.GetVillagers().ToList();
            return View(q);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Quote newQuote)
        {
          
            _quoteData.AddQuote(newQuote);
            _quoteData.CommitChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int quoteId)
        {
            Quote quoteToDelete = this._quoteData.FindById(quoteId);
            
            _quoteData.DeleteQuote(quoteToDelete);
            _quoteData.CommitChanges();
            return RedirectToAction("Index");
        }

        
    }
}