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
        private int shields;
        private int mana;
        public bool IsAlive => health > 0;

        private bool fireBuff;
        private bool iceShield;

        private int turnCounter = 0;

        private List<Card> deck = new List<Card>();
        private List<Card> hand = new List<Card>();
       
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

        public Character(string name, int health, int mana, int shields = 0)
        {
            Name = name;
            Health = health;
            Mana = mana;
            Shields = shields;
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public int Health
        {
            get { return health; }
            set { health = (value < 0) ? 0 : (value > 100) ? 100 : value; }
        }

        public int Mana
        {
            get { return mana; }
            set { mana = (value < 0) ? 0 : (value > 100) ? 100 : value; }
        }

        public int Shields
        {
            get { return shields; }
            set { shields = (value < 0) ? 0 : (value > 100) ? 100 : value; }
        }

        public void AddCardToDeck(Card card)
        {
            deck.Add(card);
        }

        public void AddCardToHand(Card card)
        {
            if (hand.Count >= handSize)
            {
                Console.WriteLine($"Hand is full.");
                return;
            }
            Console.WriteLine($"{this.Name} Drew a card.");
            hand.Add(card);
            card.count++;
        }  
        
        public List<(int index, string cardName, int count)> DisplayHand()
        {
            //Using LINQ (Language Integrated Query) to group the cards by their name and get the count of each one as well as the index in the list
            var groupedCardsInHand = hand.GroupBy(card => card.Name).Select((group, index) => (Index: index + 1, CardName: group.Key, Count: group.Count())).ToList();
            
            foreach (var group in groupedCardsInHand)
            {
                Console.WriteLine($"{group.Index}. {group.CardName}: {group.Count}");
            }

            return groupedCardsInHand;
        }

        public void DisplayStats()
        {
            Console.WriteLine($"{Name} Health: {Health} | Mana: {Mana} | Shields: {shields}");
        }
        
        public void ShuffleDeck(Card[] cards)
        {
            Random random = new Random();
            //populating player deck
            for (int i = 0; i < 60; i++)
            {
                int index = random.Next(cards.Length);
                AddCardToDeck(cards[index]);
            }            
        }

        public void DrawInitialHand(List<Card> cards)
        {
            Random random = new Random();
            //populating player deck
            for (int i = 0; i < 5; i++)
            {
                int index = random.Next(cards.Count);
                AddCardToHand(cards[index]);
            }
        }

        public void FireBuffTracker()
        {
            if (FireBuff == true)
            {
                turnCounter += 1;
                if (turnCounter % 2 == 0)
                {
                    turnCounter = 0;
                    FireBuff = false;
                    Console.WriteLine($"Fire Buff Turned Off");
                }
            }            
        }

        public void PlayACard(Character player, Character target)
        {
            var cards = DisplayHand();

            Console.WriteLine($"Choose a card to play (1, 2, 3...)");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                var selectedCard = cards.FirstOrDefault(card => card.index == choice);

                if (selectedCard.cardName != null)
                {
                    var cardToPlay = hand.FirstOrDefault(card => card.Name == selectedCard.cardName);

                    if (cardToPlay != null)
                    {
                        hand.Remove(cardToPlay);
                        cardToPlay.Play(target, player);                        
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Choice");

                }
            }
            else
            {
                Console.WriteLine("Invalid Input");

            }
        }        
    }
}
