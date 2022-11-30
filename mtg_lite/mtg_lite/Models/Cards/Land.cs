using MTGO_lite.Models.Manas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Cards
{
    public class Land : Permanent
    {
        
        protected Land(string name, Mana manaCost, Bitmap picture) : base(name, manaCost, picture)
        {
            cardType = CardType.land;
        }

        public static Land Fabrique(string stringEntree)
        {
            try
            {
                switch (stringEntree)
                {
                    case "Forest":
                        return new Land(stringEntree, new Mana(0, 0, 0, 0, 0, 0), Resource.forest);

                    case "Island":
                        return new Land(stringEntree, new Mana(0, 0, 0, 0, 0, 0), Resource.island);

                    case "Mountain":
                        return new Land(stringEntree, new Mana(0, 0, 0, 0, 0, 0), Resource.mountain);
                    
                    case "Plains":
                        return new Land(stringEntree, new Mana(0, 0, 0, 0, 0, 0), Resource.plains);
                    
                    case "Swamp":
                        return new Land(stringEntree, new Mana(0, 0, 0, 0, 0, 0), Resource.swamp);

                    default:
                        return new Land(stringEntree, new Mana(0, 0, 0, 0, 0, 0), Resource.blightning);                    
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message); 
            }
        }
    }
}
