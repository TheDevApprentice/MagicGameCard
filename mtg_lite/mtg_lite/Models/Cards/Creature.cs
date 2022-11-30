using MTGO_lite.Models.Manas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Cards
{
    public class Creature : Permanent
    {
        protected Creature(string name, Mana manaCost, Bitmap picture) : base(name, manaCost, picture)
        {
            cardType = CardType.creature;
        }

        public static Creature Fabrique(string stringEntree)
        {
            try
            {
                switch (stringEntree)
                {
                    case "barony_vampire":
                        return new Creature(stringEntree, new Mana(1, 0, 0, 0, 0, 2), Resource.barony_vampire);

                    case "canyon_minotaur":
                        return new Creature(stringEntree, new Mana(0, 0, 0, 1, 0, 3), Resource.canyon_minotaur);

                    case "scathe_zombies":
                        return new Creature(stringEntree, new Mana(1, 0, 0, 0, 0, 2), Resource.scathe_zombies);
                    default:
                        return new Creature(stringEntree, new Mana(1, 0, 0, 1, 0, 2), Resource.scathe_zombies);
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
