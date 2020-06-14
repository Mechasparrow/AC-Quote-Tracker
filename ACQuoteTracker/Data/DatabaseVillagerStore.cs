using System.Collections.Generic;
using ACQuoteTracker.Models;
using System.Linq;
using System.Linq.Expressions;

namespace ACQuoteTracker.Data
{
    public class DatabaseVillagerStore : IVillagerData
    {
        private readonly QuoteTrackerDbContext _context;

        public DatabaseVillagerStore(QuoteTrackerDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Villager> GetVillagers()
        {
            return _context.Villagers;
        }

        public Villager FindById(int ID)
        {
            var villager = _context.Villagers.FirstOrDefault(v => v.VillagerId == ID);
            return villager;
        }

        public Villager AddVillager(Villager newVillager)
        {
            var savedVillager = _context.Villagers.Add(newVillager);
            return savedVillager.Entity;
        }

        public void CommitChanges()
        {
            _context.SaveChanges();
        }
    }
}