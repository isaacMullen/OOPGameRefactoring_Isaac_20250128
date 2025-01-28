using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameRefactoring_Isaac_20250128
{
    internal class Program
    {                                
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();

            gameManager.StartGame();

            Console.ReadKey();                                                            
        }
    }
}
