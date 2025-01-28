using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameRefactoring_Isaac_20250128
{
    internal class Character
    {
        private string name;
        private int health;
        public bool IsAlive => health > 0;

        
        private List<Card> deck = new List<Card>();
        private List<Card> hand = new List<Card>();

        public Character(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = value < 0 ? 0: value; } // Ensures positive value
        }
    }
}
