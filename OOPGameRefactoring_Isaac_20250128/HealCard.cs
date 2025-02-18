﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameRefactoring_Isaac_20250128
{
    internal class HealCard : Card
    {
        int castKey = 5;
        int healAmount = 40;
        int manaCost = 40;
        string name = "Heal";

        public override void Play(Character target, Character caster)
        {
            if (caster.Mana >= manaCost)
            {
                caster.Health += healAmount;
                caster.Mana -= manaCost;
                Console.WriteLine($"{caster.Name} healed for {healAmount} HP");
            }
            else
            {
                Console.WriteLine($"Not Enough Mana!\nYour Mana: {caster.Mana} | Mana Required: {manaCost}");
            }
                       
        }

        public override int HealAmount
        {
            get { return healAmount; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Healing can't be negative");
                }
                healAmount = value;
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
