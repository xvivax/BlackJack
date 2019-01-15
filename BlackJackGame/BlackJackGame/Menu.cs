using System;
using System.Collections.Generic;

namespace BlackJackGame
{
    public class Menu
    {
        public void ShowMenu(List<Player> players)
        {
            bool showmenu = true;
            int playerCount = 0;

            while (showmenu)
            {
                Console.WriteLine("How many player going to play?");
                if (int.TryParse(Console.ReadLine(), out playerCount))
                {
                    for (int i = 0; i < playerCount; i++)
                    {
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