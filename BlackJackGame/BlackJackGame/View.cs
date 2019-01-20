using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace BlackJackGame
{
    public class View
    {
        public TextBlock dealer;
        public TextBlock player;
        public TextBlock bets;

        public void ShowDealer(Dealer dl)
        {
            List<string> dealerInfo = new List<string>();

            dealerInfo.Add(dl.Name);
            dealerInfo.Add("");
            dealerInfo.Add("-== Cards ==-");
            foreach (var card in dl.GetCards())
            {
                if (card.IsHidden)
                {
                    dealerInfo.Add("HIDDEN");
                }
                else
                {
                    dealerInfo.Add(card.ToString());
                }               
            }
            dealerInfo.Add("Points: " + dl.GetPoins().ToString());
            dealerInfo.Add("");

            if (dl.Busted)
            {
                dealerInfo.Add("BUSTED");
            }

            dealer = new TextBlock(50, 0, 15, dealerInfo);
            dealer.Render();
        }

        public void ShowPlayer(Player pl, int offset)
        {
            List<string> playerInfo = new List<string>();

            playerInfo.Add("Name: " + pl.Name);
            playerInfo.Add("Bank: $" + pl.Money);
            playerInfo.Add("");
            playerInfo.Add("-== Cards ==-");
            foreach (var card in pl.GetCards())
            {
                playerInfo.Add(card.ToString());
            }
            playerInfo.Add("Points: " + pl.GetPoins().ToString());
            playerInfo.Add("");


            if (pl.Busted)
            {
                playerInfo.Add("BUSTED");
            }
            else if (pl.Win)
            {
                playerInfo.Add(pl.Name + " won $" + pl.Bet);
            }
            else if (pl.Push)
            {
                playerInfo.Add("PUSH");
            }

            if (pl.Lose)
            {
                playerInfo.Add(pl.Name + " lose $" + pl.Bet);
            }

            player = new TextBlock(20 + offset, 13, 15, playerInfo);
            player.Render();
        }

        public void ShowWhoesTurn(Player pl, int offset)
        {
            Button turn = new Button(20 + offset, 8, pl.Name + " turn");
            turn.SetActive();
            turn.Render();
        }

        public void ShowPlacingBet(Player pl, ref int bet, int offset)
        {
            List<string> betting = new List<string>();

            betting.Add("[" + pl.Name + "]");
            betting.Add("Place your bet");
            bets = new TextBlock(20 + offset, 20, 10, betting);            
            bets.Render();
            Console.SetCursorPosition(20 + offset, 22);

            while (!int.TryParse(Console.ReadLine(), out bet) || bet < 0)
            {
                betting.Clear();
                betting.Add("Wrong bet. Try again");
                bets = new TextBlock(20 + offset, 20, 10, betting);
                bets.Render();
                Console.SetCursorPosition(20 + offset, 22);
            }

            while (pl.Money < bet)
            {
                betting.Clear();
                betting.Add("You don't have enough money to make this bet. Try again");
                bets = new TextBlock(20 + offset, 20, 10, betting);
                bets.Render();
                Console.SetCursorPosition(20 + offset, 22);
                while (!int.TryParse(Console.ReadLine(), out bet))
                {
                    betting.Clear();
                    betting.Add("Bet can only contains numbers. Try again");
                    bets = new TextBlock(20 + offset, 20, 10, betting);
                    bets.Render();
                    Console.SetCursorPosition(20 + offset, 22);
                }
            }
        }

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