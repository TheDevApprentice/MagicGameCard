using MTGO_lite.Models.Manas;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Cards
{
    public class Sorcery : Card
    {

        protected Sorcery(string name, Mana manaCost, Bitmap picture) : base(name, manaCost, false, picture)
        {
        }

        public static Sorcery Fabrique(string stringEntree)
        {
            try
            {
                switch (stringEntree)
                {
                    case "death_by_dragons":
                        return new Sorcery(stringEntree, new Mana(0, 0, 0, 2, 0, 4), Resource.death_by_dragons);
                       
                    case "chain_lightning":
                        return new Sorcery(stringEntree, new Mana(0, 0, 0, 0, 0, 1), Resource.chain_lightning);
                       
                    case "blightning":
                        return new Sorcery(stringEntree, new Mana(1, 0, 0, 1, 0, 1), Resource.blightning);
                        
                    default:
                        return new Sorcery(stringEntree, new Mana(1, 0, 0, 1, 0, 1), Resource.blightning);
                        
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
