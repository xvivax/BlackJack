using System;
using System.Collections.Generic;

namespace BlackJackGame
{
    public class Dealer : Unit
    {
        private List<Card> ownCards = new List<Card>();
        private Deck deck = new Deck();

        public string Name { get; }

        public Dealer()
        {
            cards = new List<Card>();
            Name = "Dealer";

            //TODO for testing - delete after finish
            //deck.DisplayDeck();
        }

        public void ShuffleDeck()
        {
            deck.Shuffle();
        }

        public Card DealCard()
        {
            return deck.GetCard();
        }
    }
}