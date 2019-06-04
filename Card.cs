using System;

namespace Deck
{
    class Card
    {
        public string stringVal { get; set; }
        public string suit { get; set; }
        public int val { get; set; }

        public Card(string st, string v, int value)
        {
            stringVal = st;
            suit = v;
            val = value;

        }

    }
}


