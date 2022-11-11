﻿using MTGO_lite.Models.Manas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Cards
{
    public class Permanent : Card
    {
        
        protected Permanent(string name, Mana manaCost, Bitmap picture) : base(name, manaCost, true, picture)
        {
            
        }

        
    }
}