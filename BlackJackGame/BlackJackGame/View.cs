using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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
        }

        public void DisplayBusted(Unit unit)
        {
            Console.WriteLine("BUSTED");
        }

        public void DisplayWin(Player pl)
        {
            Console.WriteLine(pl.Name + " won " + pl.Bet);
        }

        public void DisplayLose(Player pl)
        {
            Console.WriteLine(pl.Name + " lose $" + pl.Bet);
        }

        public void DisplayPush(Player pl)
        {
            Console.WriteLine("PUSH");
        }
    }
}