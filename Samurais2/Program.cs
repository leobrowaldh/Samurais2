using Samurais2.Data;
using Samurais2.Models;

namespace Samurais2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DataAccess.AddSomeRandomSamurais();

            //now to remove some samurais that have null secret identity, inserted by mistake...
            //DataAccess.RemoveSamuraisWithoutIdentity();

            List<Samurai> SamuraisInChongomango = DataAccess.GetAllSamuraisInBattle("Chongomango");
            foreach (Samurai samurai in SamuraisInChongomango)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}