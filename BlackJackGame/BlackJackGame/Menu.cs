using System;
using System.Collections.Generic;

namespace BlackJackGame
{

    public class Menu
    {
        enum State
        {
            Play,
            Quit
        }

        public int ShowMenu(List<Player> players)
        {
            bool renderWindow = true;
            State currentState = State.Play;
            ActivityChanger activityChanger = new ActivityChanger();
            List<Button> buttonsList = new List<Button>()
            {
                new Button(50, 5, "Play"),
                new Button(50, 10, "Quit")
            };

            buttonsList[0].SetActive();

            ConsoleKeyInfo keyInfo;

            do
            {
                foreach (Button button in buttonsList)
                {
                    button.Render();
                }

                while (Console.KeyAvailable)
                {
                    keyInfo = Console.ReadKey(true);

                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            if (currentState != State.Play)
                            {
                                currentState -= 1;
                                activityChanger.SetPreviousActive(buttonsList);
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            if (currentState != State.Quit)
                            {
                                currentState += 1;
                                activityChanger.SetNextActive(buttonsList);
                            }
                            break;
                        case ConsoleKey.Enter:
                            switch (currentState)
                            {
                                case State.Play:
                                    PlayersSetUp(players);
                                    break;
                                case State.Quit:
                                    return -1;
                            }
                            renderWindow = false;
                            break;
                    }
                }
                System.Threading.Thread.Sleep(100);
            } while (renderWindow);

            return 0;
        }

        public void PlayersSetUp(List<Player> players)
        {
            Console.Clear();
            bool showmenu = true;

            while (showmenu)
            {
                Console.WriteLine("How many players are going to play?");
                if (int.TryParse(Console.ReadLine(), out int playerCount))
                {
                    for (int i = 0; i < playerCount; i++)
                    {
                        Console.Clear();
                        players.Add(new Player() { });
                        Console.WriteLine("Enter player" + (i+1) + " name");
                        players[i].Name = Console.ReadLine();

                        Console.WriteLine("Enter how much money player has");
                        int money = 0;
                        while (!int.TryParse(Console.ReadLine(), out money))
                        {
                            Console.WriteLine("Wrong number. Try again.");
                            Console.WriteLine("Enter how much money player" + (i+1) + " has");
                        }
                        players[i].Money = money;
                    }
                    showmenu = false;
                }
                else
                {
                    Console.WriteLine("Wrong number. Try again.");
                }
            }
        }
    }
}