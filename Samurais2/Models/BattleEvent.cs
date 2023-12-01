using Helpers;

namespace Samurais2.Models
{
    internal class BattleEvent
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public DateTime EventOccurence { get; set; }
        public BattleLog BattleLog { get; set; }
        public void SeedData(csSeedGenerator seeder)
        {
            Description = GetEventDescription(seeder);
            Summary = "Not implemented";
            EventOccurence = seeder.DateAndTime(500, 1400);
        }

        public string GetEventDescription(csSeedGenerator seed)
        {
            List<string> EventDescriptions = new List<string>()
            {
                "the cavalry charges!", "first rank fire!", "second rank fire!", "they took the hill", "it started raining",
                "we killed their general!", "our commander has fallen!", "hand to hand combat", "a calm moment"
            };
            return seed.FromList(EventDescriptions);
        }
    }
}
