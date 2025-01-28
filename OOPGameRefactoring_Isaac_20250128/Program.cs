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
            Character player = new Character("Player", 100);

            //Initializing cards
            FireballCard fireballCard = new FireballCard();
            HealCard healCard = new HealCard();
            
            //Testing Values for Cards
            Console.WriteLine($"Card: {fireballCard.Name}\nDamage: {fireballCard.Damage}\nCost: {fireballCard.ManaCost}");
            Console.ReadKey();

            Console.WriteLine();

            Console.WriteLine($"Card: {healCard.Name}\nHeal Amount: {healCard.HealAmount}\nCost: {healCard.ManaCost}");
            Console.ReadKey();

            //Testing Fireball cast
            Console.WriteLine(player.Health);

            fireballCard.Play(player);
            healCard.Play(player);

            Console.WriteLine(player.Health);
            Console.ReadKey();
        }
    }
}
