using Helpers;

namespace Samurais2.Models
{
    internal class BattleLog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Battle Battle { get; set; }
        public int BattleId { get; set; }
        public ICollection<BattleEvent> BattleEvents { get; set; } = new List<BattleEvent>();
        public void SeedData(csSeedGenerator seeder)
        {
            Name = typeof(Battle).Name;
            int numberOfEvents = seeder.Next(0, 5);
            for (int i = 0; i < numberOfEvents; i++)
            {
                csSeedGenerator eventSeed = new csSeedGenerator();
                BattleEvent battleEvent = new BattleEvent();
                battleEvent.SeedData(eventSeed);
                BattleEvents.Add(battleEvent);
            }
        }
    }
}
