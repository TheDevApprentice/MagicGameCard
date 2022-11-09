using MTGO_lite.Models.Manas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Cards
{
    public class Land : Permanant
    {
        protected Land(string name, Mana manaCost, Bitmap picture) : base(name, manaCost, picture)
        {
        }

        public static Land Fabrique(string stringEntree)
        {
            try
            {
                switch (stringEntree)
                {
                    case "death_by_dragons":
                        return new Land(stringEntree, new Mana(0, 0, 0, 2, 0, 4), new Bitmap("death_by_dragons.png"));

                    case "chain_lightning":
                        return new Land(stringEntree, new Mana(0, 0, 0, 0, 0, 1), new Bitmap("chain_lightning.png"));

                    case "blightning":
                        return new Land(stringEntree, new Mana(1, 0, 0, 1, 0, 1), new Bitmap("blightning.png"));

                    default:
                        return new Land(stringEntree, new Mana(1, 0, 0, 1, 0, 1), new Bitmap("blightning.png")); ;

                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
