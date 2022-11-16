using mtg_lite.Models.Cards;
using mtg_lite.Models.Players;
using MTGO_lite.Models.Manas;
using MTGO_lite.Models.Manas.ManaColors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Zones
{
    public class BattleField : Zone
    {
        public override string Name { get => "BattleField"; }
        
        public BattleField(List<Card> cards, Player player) : base(cards, player)
        {
        }
        public override void GererClique(Card card)
        {            
            if (card.Tapped == false)
            {
                card.Tapped = true;
            }
            else { card.Tapped = false; }

            if (card.Tapped == true && card.CardType == CardType.land )
            {
                switch (card.Name)
                {
                    case "Forest":
                         player.ManaPool.Add(new Mana(0, 0, 1, 0, 0, 0));
                        break;
                    case "Island":
                        player.ManaPool.Add(new Mana(0, 1, 0, 0, 0, 0));
                        break;
                    case "Mountain":
                        player.ManaPool.Add(new Mana(0, 0, 1, 0, 0, 0));
                        break;
                    case "Plains":
                        player.ManaPool.Add(new Mana(0, 0, 0, 1, 0, 0));
                        break;
                    case "Swamp":
                        player.ManaPool.Add(new Mana(1, 0, 0, 0, 0, 0));
                        break;
                    default:
                        player.ManaPool.Add(new Mana(0, 0, 0, 0, 0, 0));
                        break;
                }
                MessageBox.Show(card.Tapped.ToString());
            }                
        }      
    }
}
