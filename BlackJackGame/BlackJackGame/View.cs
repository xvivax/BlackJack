using System;
using System.Collections.Generic;

namespace BlackJackGame
{
    public class View
    {
        public void DisplayPlayerInfo(Player pl)
        {
            Console.WriteLine(pl.Name);
            Console.WriteLine("$" + pl.Money);
        }

        public void DisplayDealerInfo(Dealer dl)
        {
            Console.WriteLine(dl.Name);
        }

        public void DisplayCards(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card);
            }
        }

        public void DisplayPoints(Unit unit)
        {
            Console.WriteLine(unit.GetPoins());
            Console.WriteLine();
        }
    }
}