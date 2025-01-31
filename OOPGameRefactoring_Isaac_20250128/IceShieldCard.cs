using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameRefactoring_Isaac_20250128
{
    internal class IceShieldCard : Card 
    {
        int castKey = 4;
        int shieldMod = 30;
        int manaCost = 20;
        string name = "Ice Shield";

        public override void Play(Character target, Character caster)
        {
            if (caster.Mana >= manaCost)
            {
                caster.IceShield = true;
                caster.Shields += 30;
                caster.Mana -= manaCost;
                Console.WriteLine($"{caster.Name} Gained {shieldMod} shield and Ice Armor Status (fire resist)");
            }
            else
            {
                Console.WriteLine($"Not Enough Mana!\nYour Mana: {caster.Mana} | Mana Required: {manaCost}");
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
