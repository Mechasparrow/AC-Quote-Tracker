using System.Linq;
using ACQuoteTracker.Models;

namespace ACQuoteTracker.Data
{
    public class DbInitializer
    {
        public static void Initialize(QuoteTrackerDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Villagers.Any())
            {
                return;   // DB has been seeded
            }

            var villagers = InMemoryVillagerStore.ReadInVillagers();

            context.Villagers.AddRange(villagers);
            context.SaveChanges();

        }
    }
}