using System.Collections.Generic;

namespace BlackJackGame
{
    public class Unit
    {
        protected int points = 0;
        protected List<Card> cards;

        public List<Card> GetCards()
        {
            return cards;
        }

        public void AddCard(Card card)
        {
            cards.Add(card);
        }

        public int GetPoins()
        {
            return points;
        }

        public void SetPoints(int p)
        {
            points = p;
        }
    }
}