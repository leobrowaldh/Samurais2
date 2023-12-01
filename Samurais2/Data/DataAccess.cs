using Helpers;
using Samurais2.Models;

namespace Samurais2.Data
{
    internal class DataAccess
    {
        public static void AddSomeRandomSamurais()
        {
            using (Context context = new Context())
            {
                for (int i = 0; i < 20; i++)
                {
                    csSeedGenerator seed = new csSeedGenerator();
                    Samurai samurai = new Samurai();
                    samurai.SeedData(seed);

                    context.Samurais.Add(samurai);
                }
                context.SaveChanges();
            }
        }
        private static void CreateSamurai(Samurai samurai)
        {
            using (Context context = new Context())
            {
                context.Samurais.Add(samurai);
                context.SaveChanges();
            }
        }
        public static void RemoveSamuraisWithoutIdentity()
        {
            using (Context context = new Context())
            {
                var SamuraisToRemove = context.Samurais
                    .Where(s => s.SecretIdentity == null)
                    .ToList();

                foreach (var Samurai in SamuraisToRemove)
                {
                    context.Samurais.Remove(Samurai);
                }
                context.SaveChanges();
            }

        }

        public static List<Samurai> GetAllSamuraisInBattle(string battleName)
        {
            using (var context = new Context())
            {
                List<Samurai> SamuraisInBattle = context.Samurais
                    .Where(s => s.Battles.Any(b => b.Name == battleName))
                    .ToList();
                return SamuraisInBattle;
            }
        }
    }
}
