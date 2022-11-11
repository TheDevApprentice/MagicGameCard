﻿using mtg_lite.Models.Cards;
using mtg_lite.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Zones
{
    public class BattleField : Zone
    {
        public override string Name { get => "Battlefield"; }
        public BattleField(List<Card> cards, Player player) : base(cards, player)
        {
        }
        public override void GererClique(Card card)
        {
            this.RemoveCard(card);
        }
    }
}
