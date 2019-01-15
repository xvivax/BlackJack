using System;
using System.Collections.Generic;

namespace BlackJackGame
{
    public class Player : Unit
    {
        public string Name { get; set; }
        public int Money { get; set; }

        public Player()
        {
            cards = new List<Card>();
        }
    }
}