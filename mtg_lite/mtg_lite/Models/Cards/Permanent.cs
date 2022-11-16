﻿using MTGO_lite.Models.Manas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Cards
{
    public abstract class Permanent : Card
    {
        
        protected Permanent(string name, Mana manaCost, CardType cardType, Bitmap picture) : base(name, manaCost, true, CardType.vide, picture)
        {
            
        }

        
    }
}
