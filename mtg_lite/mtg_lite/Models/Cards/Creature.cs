using MTGO_lite.Models.Manas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Cards
{
    public class Creature : Permanant
    {
        protected Creature(string name, Mana manaCost, Bitmap picture) : base(name, manaCost, picture)
        {
        }

        public static Creature Fabrique(string stringEntree)
        {
            try
            {
                switch (stringEntree)
                {
                    case "death_by_dragons":
                        return new Creature(stringEntree, new Mana(0, 0, 0, 2, 0, 4), new Bitmap("death_by_dragons.png"));

                    case "chain_lightning":
                        return new Creature(stringEntree, new Mana(0, 0, 0, 0, 0, 1), new Bitmap("chain_lightning.png"));

                    case "blightning":
                        return new Creature(stringEntree, new Mana(1, 0, 0, 1, 0, 1), new Bitmap("blightning.png"));

                    default:
                        return new Creature(stringEntree, new Mana(1, 0, 0, 1, 0, 1), new Bitmap("blightning.png")); ;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
