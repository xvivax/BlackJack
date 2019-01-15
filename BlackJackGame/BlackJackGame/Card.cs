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
        Ace,
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

        public Card()
        {

        }

        public Card(Suit suit, Value value)
        {
            this.suit = suit;
            this.value = value;
        }

        public override string ToString()
        {
            return $"{value} of {suit}";
        }
    }
}