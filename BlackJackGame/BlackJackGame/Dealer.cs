using System;
using System.Collections.Generic;

namespace BlackJackGame
{
    public class Dealer : IAddCard
    {
        private List<Card> ownCards = new List<Card>();
        private Deck deck = new Deck();

        public string Name { get; } = "Dealer";

        public Dealer()
        {
        }

        public void ShuffleDeck()
        {
            deck.Shuffle();
        }

        public void AddCard(Card card)
        {
            ownCards.Add(card);
        }

        public List<Card> GetDealerCards()
        {
            return ownCards;
        }

        public Card DealCard()
        {
            return deck.GetCard();
        }
    }
}