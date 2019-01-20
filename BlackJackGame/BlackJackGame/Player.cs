using System;
using System.Collections.Generic;
using System.Dynamic;

namespace BlackJackGame
{
    public class Player : Unit
    {
        public string Name { get; set; }
        public int Money { get; set; }
        public int Bet { get; set; }
        public bool Busted { get; set; } = false;
        public bool Win { get; set; } = false;

        public Player()
        {
            cards = new List<Card>();
        }

        public void Hit(Dealer dl)
        {
            AddCard(dl.DealCard());
        }
    }
}