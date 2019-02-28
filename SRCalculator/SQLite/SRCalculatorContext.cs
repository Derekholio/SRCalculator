using Microsoft.EntityFrameworkCore;

namespace SRCalculator.SQLite
{
    public class SRCalculatorContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=srcalculator.db");
        }
    }
}
