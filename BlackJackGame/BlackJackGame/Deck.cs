using System;
using System.Collections.Generic;

namespace BlackJackGame
{
    public class Deck
    {
        private List<Card> lDeck = new List<Card>();
        private Queue<Card> qDeck = new Queue<Card>();

        Random rnd = new Random();

        // TODO For testing, delete after finishing
        public void DisplayDeck()
        {
            int i = 0;
            foreach (Card card in lDeck)
            {
                Console.WriteLine(card + " " + i);
                i++;
            }
        }

        public Deck()
        {
            CreateDeck();
            Shuffle();
            Shuffle();
            Shuffle();
        }

        public void CreateDeck()
        {
            // Suits loop
            for (int i = 0; i < 4; i++)
            {
                // Value loop
                for (int j = 0; j < 13; j++)
                {
                    lDeck.Add(new Card((Suit)i, (Value)j));
                }
            }
        }

        public void Shuffle()
        {
            for (int i = 0; i < lDeck.Count; i++)
            {
                int num = rnd.Next(0, lDeck.Count);
                Card temp = lDeck[i];
                lDeck[i] = lDeck[num];
                lDeck[num] = temp;
            }

            ConvertToQueueDeck();
        }

        public void ConvertToQueueDeck()
        {
            qDeck.Clear();
            foreach (Card card in lDeck)
            {
                qDeck.Enqueue(card);
            }
        }

        public Card GetCard()
        {
            return qDeck.Dequeue();
        }
    }
}