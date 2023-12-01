using Helpers;

namespace Samurais2.Models
{
    internal class Battle
    {
        public int Id { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }

            set
            {
                if (Enum.TryParse<enBattles>(value, out _))
                {
                    _name = value;
                }
                else
                {
                    throw new ArgumentException("Must be a valid enBattles selection.");
                }
            }
        }
        public string Description { get; set; }
        public bool Brutal { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ICollection<Samurai> Samurais { get; set; } = new List<Samurai>();
        public BattleLog BattleLog { get; set; }
        public void SeedData(csSeedGenerator seeder)
        {
            Name = seeder.FromEnum<enBattles>().ToString();
            Description = GetBattleDescription(seeder);
            Brutal = seeder.Bool;
            StartDate = seeder.DateAndTime(500, 1400);
            EndDate = seeder.DateAndTime(StartDate.Year, StartDate.Year + 1);
            BattleLog battleLog = new BattleLog();
            battleLog.SeedData(seeder);
            BattleLog = battleLog;
        }
        public string GetBattleDescription(csSeedGenerator seed)
        {
            List<string> BattleDescriptions = new List<string>()
            {
                "A terrible battle", "All died", "Minor clash", "Gunpowder massacre", "Hell on earth", "Heroic stand", "A battle for love"
            };
            return seed.FromList(BattleDescriptions);
        }
    }
    enum enBattles { Chongomango, The_Crossings, CitadelInvasion, Caracoquesos, TheFiveArmies, LastStand, Kirosawa, Chakabuko, Hells_Gate, Nioshiwa }
}

