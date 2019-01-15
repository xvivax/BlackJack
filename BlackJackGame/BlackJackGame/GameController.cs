using System;
using System.Collections.Generic;

namespace BlackJackGame
{
    public class GameController
    {
        Dealer dealer = new Dealer();

        //Player player1 = new Player() {};
        View view = new View();

        private List<Player> players = new List<Player>()
        {
            new Player() {Name = "viva", Money = 100},
            new Player() {Name = "Misha", Money = 500}
        };

        public void Init()
        {
            // Give two initial cards to the dealer and player[s]
            for (int i = 0; i < 2; i++)
            {
                dealer.AddCard(dealer.DealCard());
                foreach (Player player in players)
                {
                    player.AddCard(dealer.DealCard());
                }
            }

            // Display
            view.DisplayDealerInfo(dealer);
            view.DisplayCards(dealer.GetDealerCards());

            foreach (Player player in players)
            {
                view.DisplayPlayerInfo(player);
                view.DisplayCards(player.GetCards());
            }
        }

        public void Game()
        {
            players[0].Hit();
        }

    }
}