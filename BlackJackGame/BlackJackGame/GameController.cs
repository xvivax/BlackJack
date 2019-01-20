using System;
using System.Collections.Generic;

namespace BlackJackGame
{
    public class GameController
    {
        enum State
        {
            Hit,
            Stand
        }

        private ActivityChanger activityChanger = new ActivityChanger();
        private Menu menu = new Menu();
        private Dealer dealer = new Dealer();
        private View view = new View();

        private List<Player> players = new List<Player>();

        List<Button> buttonsList = new List<Button>()
        {
            new Button(20, 15, "Hit"),
            new Button(30, 15, "Stand")
        };

        public void Game()
        {
            if (menu.ShowMenu(players) != -1)
            {
                InitCards();
                Betting();

                while (true)
                {
                    Update();
                    Render();
                }
            }
        }

        private void Update()
        {
            Render();
            HitStand();
            HitStandDealer();
            CalcWinner();
            Console.ReadLine();
        }

        private void HitStand()
        {
            for (int i = 0; i < players.Count; i++)
            {

                //Console.WriteLine("-=== " + players[i].Name + " turn ===-");
                State currentState = State.Hit;
                buttonsList[0].SetActive();
                buttonsList[1].SetNotActive();

                ConsoleKeyInfo keyInfo;

                bool needMoreCards = true;
                do
                {
                    Console.Clear();
                    CalculatePoints(players[i]);
                    if (players[i].GetPoins() > 21)
                    {
                        players[i].Busted = true;
                        Render();
                        needMoreCards = false;
                    }
                    else
                    {
                        Render();

                        RenderHitStand();

                        while (Console.KeyAvailable)
                        {
                            keyInfo = Console.ReadKey(true);

                            switch (keyInfo.Key)
                            {
                                case ConsoleKey.LeftArrow:
                                    if (currentState != State.Hit)
                                    {
                                        currentState -= 1;
                                        activityChanger.SetPreviousActive(buttonsList);
                                    }
                                    break;
                                case ConsoleKey.RightArrow:
                                    if (currentState != State.Stand)
                                    {
                                        currentState += 1;
                                        activityChanger.SetNextActive(buttonsList);
                                    }
                                    break;
                                case ConsoleKey.Enter:
                                    switch (currentState)
                                    {
                                        case State.Hit:
                                            players[i].Hit(dealer);
                                            break;
                                        case State.Stand:
                                            needMoreCards = false;
                                            break;
                                    }
                                    break;
                            }
                        }
                        System.Threading.Thread.Sleep(100);
                    }
                    
                } while (needMoreCards);
            }
        }

        private void Betting()
        {
            for (int i = 0; i < players.Count; i++)
            {
                bool pass = false;
                while (!pass)
                {
                    Console.Clear();
                    Console.WriteLine("-====Player" + (i + 1) + "====-");
                    Console.WriteLine("Place your bet");
                    int bet = 0;
                    while (!int.TryParse(Console.ReadLine(), out bet))
                    {
                        Console.WriteLine("Bet can only contains numbers. Try again");
                    }

                    while (players[i].Money < bet)
                    {
                        Console.WriteLine("You don't have enough money to make this bet. Try again");
                        bet = Convert.ToInt32(Console.ReadLine());
                    }

                    players[i].Bet = bet;
                    players[i].Money -= bet;
                    pass = true;
                    Console.Clear();
                }
            }
        }

        private void InitCards()
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

            CalcAllPoints();
            Render();
        }

        private void CalculatePoints(Unit unit)
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

        private void CalcAllPoints()
        {
            CalculatePoints(dealer);

            foreach (Player player in players)
            {
                CalculatePoints(player);
            }
        }

        private void HitStandDealer()
        {
            while (dealer.GetPoins() <= 16)
            {
                dealer.AddCard(dealer.DealCard());
                CalculatePoints(dealer);
                Console.Clear();
                Render();
                System.Threading.Thread.Sleep(1000);
            }

            if (dealer.GetPoins() > 21)
            {
                dealer.Busted = true;
                Console.Clear();
                Render();
            }
        }

        private void CalcWinner()
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (!players[i].Busted)
                {
                    if (dealer.Busted)
                    {
                        players[i].Win = true;
                        players[i].Money += players[i].Bet;
                    }
                    else if (players[i].GetPoins() > dealer.GetPoins())
                    {
                        players[i].Win = true;
                        players[i].Money += players[i].Bet;
                        Console.Clear();
                        Render();
                    }
                    else
                    {
                        view.DisplayLose(players[i]);
                    }
                }
            }
        }

        public void Render()
        {
            // Display Dealer Info
            view.DisplayDealerInfo(dealer);
            view.DisplayCards(dealer.GetCards());
            view.DisplayPoints(dealer);
            if (dealer.Busted)
            {
                view.DisplayBusted(dealer);
            }

            // Display players Info
            foreach (Player player in players)
            {
                view.DisplayPlayerInfo(player);
                view.DisplayCards(player.GetCards());
                view.DisplayPoints(player);
                if (player.Busted)
                {
                    view.DisplayBusted(player);
                }
                else if (player.Win)
                {
                    view.DisplayWin(player);
                }
            }

            Console.WriteLine();
        }

        private void RenderHitStand()
        {
            foreach (Button button in buttonsList)
            {
                button.Render();
            }
        }

    }
}