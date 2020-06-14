using Microsoft.EntityFrameworkCore;

namespace ACQuoteTracker.Models
{
    public class QuoteTrackerDbContext : DbContext
    {
        public QuoteTrackerDbContext(DbContextOptions<QuoteTrackerDbContext> options) : base(options)
        {
            
        }

        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Villager> Villagers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Quote>()
                .HasOne(q => q.Villager)
                .WithMany(v => v.Quotes);
        }
    }
}