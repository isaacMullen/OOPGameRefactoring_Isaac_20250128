using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameRefactoring_Isaac_20250128
{
    internal class SlashCard : Card
    {
        int damage = 20;
        int manaCost = 20;
        string name = "Slash";

        public override void Play(Character target)
        {
            target.Health -= damage;
            Console.WriteLine($"Dealt {damage} damage to {target.Name}");
        }

        public override int Damage
        {
            get { return damage; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Damage can't be negative");
                }
                damage = value;
            }
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

