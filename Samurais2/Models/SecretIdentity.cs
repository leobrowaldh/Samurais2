using Helpers;

namespace Samurais2.Models
{
    internal class SecretIdentity
    {
        public int Id { get; set; }
        public string Identity { get; set; }
        public int SamuraiId { get; set; }
        public Samurai Samurai { get; set; }

        public void SeedData(csSeedGenerator seeder)
        {
            Identity = seeder.PetName;
        }
    }
}
