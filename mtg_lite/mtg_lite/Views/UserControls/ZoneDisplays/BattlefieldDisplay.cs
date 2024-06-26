﻿using mtg_lite.Models.Cards;
using mtg_lite.Models.Zones;
using mtg_lite.Views.UserControls.CardDisplays;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace mtg_lite.Views.UserControls.ZoneDisplays
{
    public partial class BattlefieldDisplay : UserControl
    {
        private BattleField? battlefield;

        public BattleField? Battlefield { get => battlefield; set => ChangeBattlefield(value); }

        public BattlefieldDisplay()
        {
            InitializeComponent();
        }

        private void ChangeBattlefield(BattleField? newBattlefield)
        {
            BattlefieldUnsubscribe();
            battlefield = newBattlefield;
            DisplayBattlefield();
            BattlefieldSubscribe();
        }

        private void DisplayBattlefield()
        {
            if (battlefield is null) { return; }

            grpBattlefield.Text = battlefield.ToString();
            landsDisplay.Cards = battlefield.GetAllLands();
            creaturesDisplay.Cards = battlefield.GetAllCreatures();
        }

        private void BattlefieldUnsubscribe()
        {
            if (battlefield is null) { return; }
            battlefield.CardsChanged -= Battlefield_CardsChanged;            
        }

        private void BattlefieldSubscribe()
        {
            if (battlefield is null) { return; }
            battlefield.CardsChanged += Battlefield_CardsChanged;            
        }

        private void Battlefield_CardsChanged(object? sender, List<Card> cards)
        {
            DisplayBattlefield();
        }

        private void cardsDisplay_CardClicked(object sender, Card card)
        {
            card.TappedChanged += Card_TappedChanged;
            battlefield?.GererClique(card);            
        }

        private void Card_TappedChanged(object? sender, bool e)
        {
            DisplayBattlefield();
        }
    }
}
