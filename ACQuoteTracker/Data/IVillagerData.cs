using System.Collections.Generic;
using ACQuoteTracker.Models;

namespace ACQuoteTracker.Data
{
    public interface IVillagerData
    {
        public IEnumerable<Villager> GetVillagers();
        public Villager FindById(int ID);
        public Villager AddVillager(Villager newVillager);
    }
}