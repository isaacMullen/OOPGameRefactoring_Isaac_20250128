﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameRefactoring_Isaac_20250128
{
    internal class GameManager
    {
        private Character player;
        private Character enemy; 
        
        Random random = new Random();

        public Card[] cards = new Card[]
        {
            new FireballCard(),
            new HealCard(),
            new SlashCard(),
            new PowerUpCard(),
            new IceShieldCard(),
        };

                
        private enum GameState { PlayerTurn, EnemyTurn, GameOver }

        private GameState currentGameState;
        
        private void PlayerTurn()
        {                        
            Console.WriteLine($"-------Player Turn-------");
            //will auto draw each turn if the current amount of cards in hand is less than 5
            player.AddCardToHand(player.Deck[random.Next(player.Deck.Count)]);

            player.FireBuffTracker();

            player.DisplayStats();            

            //playing a random card from player's hand
            player.PlayACard(player, enemy);

            Console.ReadKey();
            currentGameState = GameState.EnemyTurn;
            Console.WriteLine();
        }

        private void EnemyTurn()
        {
            Console.WriteLine("-------Enemy Turn-------");
            //will auto draw each turn if the current amount of cards in hand is less than 5
            enemy.AddCardToHand(enemy.Deck[random.Next(player.Deck.Count)]);

            enemy.DisplayStats();

            enemy.DisplayHand();

            //playing a random card from enemy's hand
            enemy.Hand[random.Next(player.Hand.Count)].Play(player, enemy);

            Console.ReadKey();
            currentGameState = GameState.PlayerTurn;
            Console.WriteLine();
        }

        private void SetUpGame()
        {
            Console.WriteLine("Setting up game");
            
            player = new Character("Player", 100, 10000);
            enemy = new Character("Enemy", 100, 10000);

            player.ShuffleDeck(cards);
            enemy.ShuffleDeck(cards);

            player.DrawInitialHand(player.Deck);
            enemy.DrawInitialHand(enemy.Deck);

            Console.ReadKey();
            currentGameState = GameState.PlayerTurn;
        }

        public void StartGame()
        {
            SetUpGame();

            while (currentGameState != GameState.GameOver && player.Deck.Count > 0 && player.Hand.Count > 0)
            {
                CheckVictory(player, enemy);
                switch (currentGameState)
                {
                    case GameState.PlayerTurn:
                        PlayerTurn();                        
                        break;
                    
                    case GameState.EnemyTurn:
                        EnemyTurn();
                        break;
                    
                    default:                        
                        break;
                }
            }
        }

        public bool CheckVictory(Character player, Character enemy)
        {
            if (!player.IsAlive)
            {
                Console.WriteLine("You lose");
                currentGameState = GameState.GameOver;
                return true;
            }

            if (!enemy.IsAlive)
            {
                Console.WriteLine("You Win!");
                currentGameState = GameState.GameOver;
                return true;
            }
            return false;
        }        
    }
}
