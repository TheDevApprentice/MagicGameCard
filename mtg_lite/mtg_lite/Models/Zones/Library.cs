using mtg_lite.ExceptionsMaison;
using mtg_lite.Models.Cards;
using mtg_lite.Models.Cards.CardBacks;
using mtg_lite.Models.Players;

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
            try
            {
                if(cards.Count == 0)
                {
                    throw new LibraryVide("La library est vide.");
                }
                RemoveTopCard();
            }
            catch (Exception e )
            {
                MessageBox.Show(e.Message);
            }                           
        }
        public override Card TopCard
        {
            get
            {
                if (cards.Count == 0)
                {
                    return new DarkCardBack();
                }                                 
                return new CardBack();
            }
        }
    }
}
