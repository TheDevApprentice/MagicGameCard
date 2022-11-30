﻿using mtg_lite.Models.Cards;
using mtg_lite.Models.Cards.CardBacks;
using mtg_lite.Models.Players;
using mtg_lite.Views.UserControls.CardDisplays;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Zones
{
    public class Zone
    {
        protected List<Card> cards;
        protected Player player;

        public List<Card> Cards { get { return cards; } }
        public virtual string Name { get => "Zone"; }
        public virtual Card TopCard {
            get
            {
                if (cards.Count == 0)
                {
                    return new DarkCardBack();
                }
                return cards[cards.Count - 1];
            }
        }
        public virtual void GererClique(Card card) { }
    
        public event EventHandler<List<Card>>? CardsChanged;
        public event EventHandler<Card>? CardAdded;
        public event EventHandler<Card>? CardRemoved;

        public Zone(List<Card> cards, Player player)
        {
            this.cards = cards;
            this.player = player;
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
            CardAdded?.Invoke(this, card);
            CardsChanged?.Invoke(this, cards);
        }

        public void RemoveCard(Card cardToRemove)
        {
            var index = cards.FindIndex(card => card == cardToRemove);
            cards.RemoveAt(index);
            CardRemoved?.Invoke(this, cardToRemove);
            CardsChanged?.Invoke(this, cards);
        }

        protected void RemoveTopCard()
        {
            Card carteTop = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            CardRemoved?.Invoke(this, carteTop);
            CardsChanged?.Invoke(this, cards);
        }
        //public virtual List<Card> GetAllLands() { return cards; }
        //public virtual List<Card> GetAllCreatures() { return cards; }

        public override string ToString()
        {
            return $"{Name} ({cards.Count})";
        }
    }
}
