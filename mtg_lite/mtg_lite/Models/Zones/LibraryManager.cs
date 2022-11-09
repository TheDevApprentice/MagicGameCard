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
        private static List<Card> deckRN = new List<Card>();

        static LibraryManager()
        {
            deckRN.Add(Sorcery.Fabrique("death_by_dragons"));
            deckRN.Add(Sorcery.Fabrique("chain_lightning"));
            deckRN.Add(Sorcery.Fabrique("blightning"));
            deckRN.Add(Creature.Fabrique("barony_vampire"));
            deckRN.Add(Creature.Fabrique("canyon_minotaur"));
            deckRN.Add(Creature.Fabrique("scathe_zombies"));
            deckRN.Add(Land.Fabrique("Mountain"));
            deckRN.Add(Land.Fabrique("Mountain"));
            deckRN.Add(Land.Fabrique("Swamp"));
            deckRN.Add(Land.Fabrique("Swamp"));
        }

        public static List<Card> GetCards(string libraryName)
        {
            if (libraries.ContainsKey(libraryName))
            {
                return libraries[libraryName];
            }
            return new List<Card>();
        }
       
        
    }
}
