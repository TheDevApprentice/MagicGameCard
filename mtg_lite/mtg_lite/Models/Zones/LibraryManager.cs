using mtg_lite.Models.Cards;
using MTGO_lite.Models.Manas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Zones
{
    public static class LibraryManager
    {
        private static Dictionary<string, List<Card>> libraries = new Dictionary<string, List<Card>>();
        
        static LibraryManager()
        {
            AjouterListeDeCartesRed();
        }

        public static List<Card> GetCards(string libraryName)
        {
            
            if (libraries.ContainsKey(libraryName))
            {
                return libraries[libraryName];
            }
            return new List<Card>();
        }

        public static void AjouterListeDeCartesRed()
        {
            List<Card> Red = new()
            {
                Sorcery.Fabrique("death_by_dragons"),
                Sorcery.Fabrique("chain_lightning"),
                Sorcery.Fabrique("blightning"),
                Creature.Fabrique("barony_vampire"),
                Creature.Fabrique("canyon_minotaur"),
                Creature.Fabrique("scathe_zombies"),
                Land.Fabrique("Mountain"),
                Land.Fabrique("Mountain"),
                Land.Fabrique("Swamp"),
                Land.Fabrique("Swamp"),
               
            };
            libraries.Add("Red", Red);            
        }


    }
}
