using System;

namespace VillagerScraper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Scraper!");
            var scraper = new Scraper();
            scraper.Start();
        }
    }
}