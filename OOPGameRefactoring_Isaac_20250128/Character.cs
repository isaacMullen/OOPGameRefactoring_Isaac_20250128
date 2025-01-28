using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPGameRefactoring_Isaac_20250128
{
    internal class Character
    {
        public const int handSize = 5;

        private string name;
        private int health;
        public bool IsAlive => health > 0;

        private bool fireBuff;
        private bool iceShield;

        private List<Card> deck = new List<Card>();
        private List<Card> hand = new List<Card>();

        private List<Card> cards = new List<Card>();

        public bool FireBuff
        {
            get { return fireBuff; }
            set { fireBuff = value; }
        }

        public bool IceShield
        {
            get { return iceShield; }
            set { iceShield = value; }
        }
        
        public List<Card> Deck
        {
            get { return deck; }
        }

        public List<Card> Hand
        {
            get { return hand; }
        }

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

        public void AddCardToDeck(Card card)
        {
            deck.Add(card);
        }

        public void AddCardToHand(Card card)
        {
            if (hand.Count >= handSize)
            {
                Console.WriteLine($"Cannot draw card, Hand is full.");
                return;
            }
            hand.Add(card);
            card.count++;
        }  
        
        public void DisplayHand()
        {
            //Using LINQ (Language Integrated Query) to group the cards by their name and get the count of each one
            var groupedCardsInHand = hand.GroupBy(card => card.Name).Select(group => new 
            { 
                CardName = group.Key,
                Count = group.Count()
            });
            
            foreach (var group in groupedCardsInHand)
            {
                Console.WriteLine($"{group.CardName}: {group.Count}");
            }
        }
    }
}
