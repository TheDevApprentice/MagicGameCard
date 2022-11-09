using MTGO_lite.Models.Manas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Cards
{
    internal class Sorcery
    {

        public Sorcery(string name, Mana manaCost, Bitmap picture) : base(name, manaCost, picture)
        {
        }

        public static Sorcery Fabrique(string stringEntree)
        {
            try
            {
                switch (stringEntree)
                {
                    case "death_by_dragons":
                        return new Sorcery(stringEntree, new Mana(0, 0, 0, 2, 0, 4), new Bitmap("death_by_dragons.pgn"));
                        break;
                    case "chain_lightning":
                        return new Sorcery(stringEntree, new Mana(0, 0, 0, 0, 0, 1), new Bitmap("chain_lightning.pgn"));
                        break;
                    case "blightning":
                        return new Sorcery(stringEntree, new Mana(1, 0, 0, 1, 0, 1), new Bitmap("blightning.pgn"));
                        break;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
