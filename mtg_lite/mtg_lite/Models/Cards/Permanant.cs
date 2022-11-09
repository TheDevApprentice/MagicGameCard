using MTGO_lite.Models.Manas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Cards
{
    public class Permanant : Card
    {
        public bool EstUnPermanant; 
        protected Permanant(string name, Mana manaCost, Bitmap picture) : base(name, manaCost, picture)
        {
        }

        
    }
}
