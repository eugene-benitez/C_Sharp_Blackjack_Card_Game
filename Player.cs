using System;
using System.Collections.Generic;

namespace Deck
{
    class Player
    {
        public string Name { get; set; }

        public List<Card> Hand { get; set; }

        public Player(string n)
        {
            Name = n;
            Hand = new List<Card>();
        }

        public Card Draw(Deck myDeck)
        {
            Card drawn = myDeck.Deal();
            Hand.Add(drawn);
            return drawn;
        }

        public Card Discard(int i)
        {
            if (i > Hand.Count)
            {
                return null;
            }
            else
            {
                Card temp = Hand[i];
                Hand.RemoveAt(i);
                return temp;
            }
        }
    }
}
