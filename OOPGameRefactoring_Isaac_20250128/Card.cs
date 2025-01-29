using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameRefactoring_Isaac_20250128
{
    abstract class Card
    {                
        public abstract void Play(Character target, Character caster);

        public int count = 1;

        public virtual string Name { get; set; } = "Generic Card";

        public virtual int Damage { get; set; } = 0;

        public virtual int ManaCost { get; set; } = 0;

        public virtual int HealAmount { get; set; } = 0;
        
    }
}
