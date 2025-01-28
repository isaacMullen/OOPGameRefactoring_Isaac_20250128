using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameRefactoring_Isaac_20250128
{
    internal class IceShieldCard : Card 
    {
        int shieldMod = 30;
        int manaCost = 20;
        string name = "Ice Shield";

        public override void Play(Character target)
        {
            target.IceShield = true;
            Console.WriteLine($"Gained {shieldMod} shield and Ice Shield");
        }        

        public override int ManaCost
        {
            get { return manaCost; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Cost can't be negative");
                }
                manaCost = value;
            }
        }
        public override string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
