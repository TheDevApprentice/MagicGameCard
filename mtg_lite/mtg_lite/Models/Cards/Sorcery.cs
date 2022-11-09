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
                        return new Sorcery(stringEntree, new Mana(0, 0, 0, 2, 0, 4), new Bitmap("death_by_dragons.png"));
                       
                    case "chain_lightning":
                        return new Sorcery(stringEntree, new Mana(0, 0, 0, 0, 0, 1), new Bitmap("chain_lightning.png"));
                       
                    case "blightning":
                        return new Sorcery(stringEntree, new Mana(1, 0, 0, 1, 0, 1), new Bitmap("blightning.png"));
                        
                    default:
                        return new Sorcery(stringEntree, new Mana(1, 0, 0, 1, 0, 1), new Bitmap("blightning.png"));
                        
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
