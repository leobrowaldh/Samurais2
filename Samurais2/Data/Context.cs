using Microsoft.EntityFrameworkCore;
using Samurais2.Models;

namespace Samurais2.Data
{
    internal class Context : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        public DbSet<Battle> Battles { get; set; }
        public DbSet<SecretIdentity> SecretIdentities { get; set; }
        public DbSet<BattleLog> BattleLogs { get; set; }
        public DbSet<BattleEvent> BattleEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                    Server=localhost; 
                    Database=Samurai; 
                    Trusted_Connection=True; 
                    Trust Server Certificate=Yes; 
                    User Id=Samurai; 
                    password=Samurai");
        }
    }
}
