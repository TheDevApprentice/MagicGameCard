using System;
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
        //private int potentielColorless;
        //private int detteColorless;
        ManaColorless potentielColorless = new ManaColorless(0);
        //public ManaColorless PotentielColorless { get { return GetPotentiel(); } }
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
            potentielColorless = GetPotentiel();
            foreach (var manaColor in manaToPay.manaColors)
            {
                //if (manaColor.Key == ManaColorless.Name)
                //{
                //    //detteColorless += manaColor.Value.Quantity;
                //    continue;
                //}                
                if (manaColor.Value > manaColors[manaColor.Key] && manaColor.Value > potentielColorless /*|| detteColorless > potentielColorless*/)
                {
                    MessageBox.Show("GEtPotentiel : " + potentielColorless.ToString());
                    throw new PasAssezDeMana("Vous ne disposez pas assez de mana pour cette carte.");
                }
                //detteColorless += manaColor.Value.Quantity;
                //potentielColorless += manaColors[manaColor.Key].Quantity;
            }
            foreach (var manaColor in manaToPay.manaColors)
            {
                if (manaColor.Key == ManaColorless.Name)
                {
                    potentielColorless.Remove(manaColor.Value);
                    //continue;
                }
                else
                {
                    manaColors[manaColor.Key].Remove(manaColor.Value);
                    potentielColorless.Remove(manaColor.Value);
                }        

                //detteColorless -= manaColor.Value.Quantity;
                //potentielColorless -= manaColors[manaColor.Key].Quantity;

                //vieux :
                //manaColors["Colorless"].Add(manaColors[manaColor.Key]);
                //manaColors[manaColor.Key].Remove(manaColors[manaColor.Key]);
            }
            MessageBox.Show("GEtPotentiel : " + potentielColorless.ToString());
            //MessageBox.Show("potentielColorless : " + potentielColorless.ToString());
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
