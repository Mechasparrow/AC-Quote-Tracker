using System;
using System.Linq;
using HtmlAgilityPack;
using IronWebScraper;

namespace VillagerScraper
{
    public class Scraper
    {
        public Scraper()
        {
            
        }

        public void Start()
        {
            var html = @"https://animalcrossing.fandom.com/wiki/Villager_list_(New_Leaf)";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var node = htmlDoc.DocumentNode.SelectSingleNode(
                "//*[@id=\"mw-content-text\"]/table[2]/tbody/tr[2]/td/table");

            Console.WriteLine(node.InnerHtml);

        }
    }
}