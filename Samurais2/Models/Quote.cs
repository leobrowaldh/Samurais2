using Helpers;

namespace Samurais2.Models
{
    internal class Quote
    {
        public int Id { get; set; }
        public string MyQuote { get; set; }
        public Samurai Samurai { get; set; }
        private string _QuoteVariant;
        public string QuoteVariant
        {
            get { return _QuoteVariant; }

            set
            {
                if (Enum.TryParse<enQuoteType>(value, out _))
                {
                    _QuoteVariant = value;
                }
                else
                {
                    throw new ArgumentException("Quote must be of type Lame, Cheesy or Awesome");
                }
            }
        }
        public void SeedData(csSeedGenerator seeder)
        {
            MyQuote = seeder.Quote.Quote;
            QuoteVariant = seeder.FromEnum<enQuoteType>().ToString();
        }
    }

    public enum enQuoteType { Lame, Cheesy, Awesome }
}
