﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mtg_lite.ExceptionsMaison;
using MTGO_lite.Models.Manas.ManaColors;

namespace MTGO_lite.Models.Manas
{
    public class Mana
    {
        private Dictionary<string, ManaColor> manaColors;

        ManaColorless potentielColorless = new ManaColorless(0);
        public ManaColor White
        {
            get => manaColors[ManaWhite.Name];
        }

        public ManaColor Blue
        {
            get => manaColors[ManaBlue.Name];
        }

        public ManaColor Black
        {
            get => manaColors[ManaBlack.Name];
        }

        public ManaColor Red
        {
            get => manaColors[ManaRed.Name];
        }

        public ManaColor Green
        {
            get => manaColors[ManaGreen.Name];
        }

        public ManaColor Colorless
        {
            get => manaColors[ManaColorless.Name];
        }

        public Dictionary<string, ManaColor> ManaColors { get => manaColors; }

        public Mana(): this(0, 0, 0, 0, 0, 0)
        {
        }

        public Mana(int black, int blue, int green, int red, int white, int colorless)
        {
            manaColors = new Dictionary<string, ManaColor>()
            {
                { ManaBlack.Name, new ManaBlack(black)},
                { ManaBlue.Name, new ManaBlue(blue)},
                { ManaGreen.Name, new ManaGreen(green)},
                { ManaRed.Name, new ManaRed(red)},
                { ManaWhite.Name, new ManaWhite(white)},
                { ManaColorless.Name, new ManaColorless(colorless)},
            };
        }

        public void Pay(Mana manaToPay)
        {
            foreach (var manaColor in manaToPay.manaColors)
            {
                if (manaColor.Key == ManaColorless.Name)
                {
                    continue;
                }
                if (manaColor.Value > manaColors[manaColor.Key])
                {
                    throw new PasAssezDeMana("Vous ne disposez pas assez de mana pour cette carte.");
                }
            }
            foreach (var manaColor in manaToPay.manaColors)
            {
                if (manaColor.Key == ManaColorless.Name)
                {
                    continue;
                }
                else
                {
                    manaColors[manaColor.Key].Remove(manaColor.Value);
                }
            }
        }

        public void Add(Mana manaToAdd)
        {
            foreach (var manaColor in manaToAdd.manaColors)
            {
                manaColors[manaColor.Key].Add(manaColor.Value);
            }           
        }

        public void Remove(Mana manaToAdd)
        {
            foreach (var manaColor in manaToAdd.manaColors)
            {
                manaColors[manaColor.Key].Remove(manaColor.Value);
            }
        }

        public ManaColorless GetPotentiel()
        {
            potentielColorless = new ManaColorless(0);

            foreach (var manaColor in manaColors)
            {
                potentielColorless.Add(manaColor.Value);
            }
            return potentielColorless;
        }
    }
}
