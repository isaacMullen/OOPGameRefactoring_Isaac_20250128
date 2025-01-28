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
            isPlayerTurn = !isPlayerTurn;
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
