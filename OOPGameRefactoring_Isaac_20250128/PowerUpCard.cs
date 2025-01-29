using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OOPGameRefactoring_Isaac_20250128
{
    internal class PowerUpCard : Card
    {        
        int manaCost = 30;
        string name = "Fire Buff";

        public override void Play(Character target, Character caster)
        {
            if (caster.Mana >= manaCost)
            {
                caster.FireBuff = true;
                caster.Mana -= manaCost;
                Console.WriteLine($"{caster.Name} has been granted Fire Buff for 2 turns!");
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

