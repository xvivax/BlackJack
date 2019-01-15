using System;
using System.Collections.Generic;

namespace BlackJackGame
{
    public class Player : IAddCard
    {
        private List<Card> cards = new List<Card>();

        public string Name { get; set; }
        public int Money { get; set; }
        public int Points { get; set; }

        public Player()
        {
        }

        public List<Card> GetCards()
        {
           return cards;
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        // Give extra card
        public void Hit()
        {

        }

        // Finish your move
        public void Stand()
        {

        }

    }
}