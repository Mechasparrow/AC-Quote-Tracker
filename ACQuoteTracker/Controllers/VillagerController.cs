using System.Collections;
using System.Collections.Generic;
using ACQuoteTracker.Data;
using ACQuoteTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace ACQuoteTracker.Controllers
{
    public class VillagerController : Controller
    {

        private readonly IVillagerData _villagerData;

        private IEnumerable<Villager> Villagers { get; set; }
        
        public VillagerController( IVillagerData villagerData)
        {
            this._villagerData = villagerData;
        }
        
        
        // GET
        public IActionResult Index()
        {
            Villagers = this._villagerData.GetVillagers();
            return View(Villagers);
        }
    }
}