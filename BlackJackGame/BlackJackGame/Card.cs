using System;

namespace BlackJackGame
{
    public enum Suit
    {
        Spades,
        Diamonds,
        Hearts,
        Clubs
    }

    public enum Value
    {
        Ace = 1,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King
    }

    public class Card
    {
        private Suit suit;
        private Value value;

        public bool IsHidden { get; set; } = false;

        public Card(Suit suit, Value value)
        {
            this.suit = suit;
            this.value = value;
        }

        public override string ToString()
        {
            return $"{value} of {suit}";
        }

        public int GetValue()
        {
            return (int)value;
        }
    }
}