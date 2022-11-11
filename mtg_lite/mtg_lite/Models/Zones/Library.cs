using mtg_lite.Models.Cards;
using mtg_lite.Models.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Zones
{
    public class Library : Zone
    {
        public override string Name { get => "Library"; }

        public Library(List<Card> cards, Player player) : base(cards, player)
        {
            this.cards = BrasserCarte(cards);
        }
        public List<Card> BrasserCarte(List<Card> cards)
        {
            int i = 0;
            Random rand = new Random();
            List<Card> nouveauCards = new List<Card>();
            while (cards.Count != 0)
            {
                int x = rand.Next(0, cards.Count);
                nouveauCards.Add(cards[x]);
                cards.Remove(cards[x]);
                i++;
            }
            cards = nouveauCards;
            return cards;
        }
        public override void GererClique(Card card)
        {
            RemoveCard(card);
        }
        public override string ToString()
        {
            return $"{Name} ({cards.Count})";
        }
    }
}
