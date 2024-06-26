﻿using mtg_lite.Models.Cards;
using mtg_lite.Models.Zones;
using MTGO_lite.Models.Manas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace mtg_lite.Models.Players
{
    public class Player
    {
        private Mana manaPool;
        private BattleField battlefield;
        private Graveyard graveyard;
        private Hand hand;
        private Library library;

        public Mana ManaPool { get => manaPool; }
        public BattleField Battlefield { get => battlefield; }
        public Graveyard Graveyard { get => graveyard; }
        public Hand Hand { get => hand; }
        public Library Library { get => library; }

        public Player(string libraryName)
        {
            manaPool = new Mana();
            battlefield = new BattleField(new List<Card>(), this);
            graveyard = new Graveyard(new List<Card>(), this);
            hand = new Hand(new List<Card>(), this);
            library = new Library (LibraryManager.GetCards(libraryName), this);
            library.BrasserCarte();
            Subscribe();
        }

        public void Subscribe()
        {
            library.CardRemoved += Library_CardRemoved;
            hand.CardRemoved += hand_CardRemoved;
        }

        private void Library_CardRemoved(object? sender, Card card)
        {
            hand.AddCard(card);
        } 
        private void hand_CardRemoved(object? sender, Cards.Card card)
        {                           
        }
        public void PlayCard(Card card)
        {            
            ManaPool.Pay(card.ManaCost);            
            
            if (card.EstUnPermanent)
            {
                hand.RemoveCard(card);
                battlefield.AddCard(card);                
            }
            else
            {
                hand.RemoveCard(card);
                graveyard.AddCard(card);
            }
        }
    }
}
