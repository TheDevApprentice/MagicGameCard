﻿using mtg_lite.ExceptionsMaison;
using mtg_lite.Models.Cards;
using mtg_lite.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Zones
{
    public class Hand : Zone
    {
        public override string Name { get => "Hand"; }
       
        public Hand(List<Card> cards, Player player) : base(cards, player)
        {

        }

        public override void GererClique(Card card)
        {
            try
            {
                foreach (var couleur in card.ManaCost.ManaColors.Keys)
                {
                    if (card.ManaCost.ManaColors[couleur.ToString()] > player.ManaPool.ManaColors[couleur.ToString()])
                    {
                        throw new PasAssezDeMana("Vous ne disposez pas assez de mana pour cette carte.");
                    }
                }                
                player.PlayCard(card);
            }
            catch (Exception e )
            {
                MessageBox.Show(e.Message);
            }
           
           
        }
       
    }
}
