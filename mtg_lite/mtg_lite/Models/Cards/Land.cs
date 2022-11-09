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
        }

        public static Land Fabrique(string stringEntree)
        {
            try
            {
                switch (stringEntree)
                {
                    case "Forest":
                        return new Land(stringEntree, new Mana(0, 0, 1, 0, 0, 0), new Bitmap("forest.png"));

                    case "Island":
                        return new Land(stringEntree, new Mana(0, 1, 0, 0, 0, 0), new Bitmap("island.png"));

                    case "Mountain":
                        return new Land(stringEntree, new Mana(0, 0, 0, 1, 0, 0), new Bitmap("mountain.png"));
                    
                    case "Plains":
                        return new Land(stringEntree, new Mana(0, 0, 0, 0, 1, 0), new Bitmap("plains.png"));
                    
                    case "Swamp":
                        return new Land(stringEntree, new Mana(1, 0, 0, 0, 0, 0), new Bitmap("swamp.png"));

                    default:
                        return new Land(stringEntree, new Mana(0, 0, 0, 0, 0, 1), new Bitmap("blightning.png")); ;
                    
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
