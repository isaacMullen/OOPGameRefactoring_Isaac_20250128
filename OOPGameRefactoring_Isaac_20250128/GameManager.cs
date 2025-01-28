using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameRefactoring_Isaac_20250128
{
    internal class GameManager
    {
        public bool isPlayerTurn;        

        public void NextTurn()
        {
            Console.WriteLine("Switching turns...");
            if (isPlayerTurn)
            {
                isPlayerTurn = !isPlayerTurn;
            }                        
        }

        public void PlayerTurn()
        {
            Console.WriteLine($"Player Turn");
        }

        public void EnemyTurn()
        {
            Console.WriteLine("Enemy Turn");
        }

        public void SetUpGame()
        {
            Console.WriteLine("Setting up game");
        }

        public void StartGame()
        {
            Console.WriteLine("Starting Game");
        }

        public bool CheckVictory(Character player, Character enemy)
        {
            if (!player.IsAlive)
            {
                Console.WriteLine("You lose");
                return true;
            }

            if (!enemy.IsAlive)
            {
                Console.WriteLine("You Win!");
                return true;
            }
            return false;
        }
    }
}
