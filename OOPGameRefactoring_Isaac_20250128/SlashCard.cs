using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameRefactoring_Isaac_20250128
{
    internal class SlashCard : Card
    {
        int castKey = 3;
        int damage = 20;
        int manaCost = 20;
        string name = "Slash";

        public override void Play(Character target, Character caster)
        {
            if (caster.Mana >= manaCost)
            {
                int remainingDamage = damage; //keeping track of damage for overflow onto shield

                if (target.Shields > 0)
                {
                    if (target.Shields >= remainingDamage)
                    {
                        //shield absorbs all damage
                        target.Shields -= remainingDamage;
                        remainingDamage = 0;
                    }
                    else
                    {
                        //adjusting the remainingDamage to be applied to health after shields are checked
                        remainingDamage -= target.Shields;
                        target.Shields = 0;
                    }
                }

                //applying overflow damage to health
                target.Health -= remainingDamage;

                caster.Mana -= manaCost;

                Console.WriteLine($"{caster.Name} dealt {damage} damage to {target.Name} with {name}.");
                if (target.Shields <= 0 && remainingDamage <= 0)
                {
                    Console.WriteLine($"{caster.Name} broke the {target.Name}'s shield!");
                }
            }
            //out of mana message
            else
            {
                Console.WriteLine($"{caster.Name} does not have enough mana to use {name}.");
            }
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

