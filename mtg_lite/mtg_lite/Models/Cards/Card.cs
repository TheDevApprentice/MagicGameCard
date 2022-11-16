using MTGO_lite.Models.Manas;
using MTGO_lite.Models.Manas.ManaColors;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Cards
{
    [DebuggerDisplay("{Name}")]
    public class Card
    {
        private string name;
        private Mana manaCost;
        private Bitmap picture;
        private bool tapped;
        private bool estUnPermanent;
        private Guid guid;
        private CardType cardType;

        public string Name { get => name; }
        public Bitmap Picture { get => picture; }
        public bool Tapped { get => tapped; set => ChangeTapped(value); }
        public bool EstUnPermanent { get => estUnPermanent; }
        public Mana ManaCost { get => manaCost; }

        public event EventHandler<bool>? TappedChanged;
        public CardType CardType { get => cardType; }

        public Card(string name, Mana manaCost, bool estUnPermanent, CardType cardType, Bitmap picture)
        {
            this.name = name;
            this.manaCost = manaCost;
            this.picture = picture;
            this.estUnPermanent = estUnPermanent;
            this.cardType = cardType;
            tapped = false;
            guid = Guid.NewGuid();
        }

        private void ChangeTapped(bool value)
        {
            tapped = value;
            TappedChanged?.Invoke(this, tapped);
        }

        public static bool operator == (Card card1, Card card2)
        {
            return card1.guid == card2.guid;
        }

        public static bool operator != (Card card1, Card card2)
        {
            return !(card1 == card2);
        }        
    }
}
