using System;
using System.Collections.Generic;

namespace BlackJackGame
{
    public class GameController
    {
        private Menu menu = new Menu();
        private Dealer dealer = new Dealer();
        private View view = new View();

        private List<Player> players = new List<Player>();


        public void Game()
        {
            menu.ShowMenu(players);
            Console.Clear();

            while (true)
            {
                Update();
                Render();
            }

        }

        public void Update()
        {
            InitCards();

            CalculatePoints(dealer);

            foreach (Player player in players)
            {
                CalculatePoints(player);
            }

            for (int i = 0; i < players.Count; i++)
            {
                bool pass = false;
                while (!pass)
                {
                    Console.WriteLine("-====Player" + (i + 1) + "====-");
                    Console.WriteLine("Place your bet");
                    int bet = 0;
                    if (!int.TryParse(Console.ReadLine(), out bet))
                    {
                        Console.Clear();
                        Console.WriteLine("Bet can only contains numbers. Try again");
                        continue;
                    }

                    if (players[i].Money < bet)
                    {
                        Console.Clear();
                        Console.WriteLine("You don't have enough money to make this bet. Try again");
                        continue;
                    }

                    players[i].Bet = bet;
                    players[i].Money -= bet;
                    pass = true;
                    Console.Clear();
                }

            }

            CalcWinner();
        }

        private void CalcWinner()
        {
            
        }

        public void InitCards()
        {
            // Give two initial cards to the and player[s] and one to the dealer

            for (int i = 0; i < 2; i++)
            {
                dealer.AddCard(dealer.DealCard());
                foreach (Player player in players)
                {
                    player.AddCard(dealer.DealCard());
                }

                if (i == 1)
                {
                    // Set last card as hidden card
                    dealer.SetHiddenCard(dealer.GetCards()[1]);
                }
            }

            dealer.GetCards();
        }

        public void CalculatePoints(Unit unit)
        {
            int score = 0;

            List<Card> cards = unit.GetCards();

            foreach (Card card in cards)
            {
                // TODO fullfill game logic, add Ace's to be as 1 or 11
                if (card.GetValue() >= 10)
                {
                    score += 10;
                }
                else
                {
                    score += card.GetValue();
                }
            }

            unit.SetPoints(score);
        }

        public void Render()
        {
            // Display Dealer Info
            view.DisplayDealerInfo(dealer);
            view.DisplayCards(dealer.GetCards());
            view.DisplayPoints(dealer);

            foreach (Player player in players)
            {
                view.DisplayPlayerInfo(player);
                view.DisplayCards(player.GetCards());
                view.DisplayPoints(player);
            }
        }

    }
}