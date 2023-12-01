using Helpers;
namespace Samurais2.Models
{
    internal class Samurai
    {
        public int Id { get; set; }
        public string Name { get; set; }
        private string _hairStyle;
        public string HairStyle
        {
            get { return _hairStyle; }
            set
            {
                if (Enum.TryParse<enHairStyle>(value, out _))
                {
                    _hairStyle = value;
                }
                else
                {
                    throw new ArgumentException("Hairstyle must be Chonmage, Oicho or Western");
                }
            }
        }
        public ICollection<Quote>? Quotes { get; set; } = new List<Quote>();
        public SecretIdentity SecretIdentity { get; set; }
        public ICollection<Battle>? Battles { get; set; } = new List<Battle>();


        //The Samurai SeedData method will activte a chainreaction of instanciating and seeding for all tables.
        public void SeedData(csSeedGenerator seed)
        {
            Name = seed.FirstName + seed.LastName;

            HairStyle = seed.FromEnum<enHairStyle>().ToString();

            Quotes = new List<Quote>();
            int numberOfQuotes = seed.Next(0, 3);
            for (int i = 0; i < numberOfQuotes; i++)
            {
                csSeedGenerator quoteSeed = new csSeedGenerator();
                Quote quote = new Quote();
                quote.SeedData(quoteSeed);
                Quotes.Add(quote);
            }

            SecretIdentity secretIdentity = new SecretIdentity();
            secretIdentity.SeedData(seed);
            SecretIdentity = secretIdentity;

            Battles = new List<Battle>();
            int numberOfBattles = seed.Next(0, 4);
            for (int i = 0; i < numberOfBattles; i++)
            {
                csSeedGenerator battleSeed = new csSeedGenerator();
                Battle battle = new Battle();
                battle.SeedData(battleSeed);
                Battles.Add(battle);
            }
        }
    }

    public enum enHairStyle { Chonmage, Oicho, Western }
}
