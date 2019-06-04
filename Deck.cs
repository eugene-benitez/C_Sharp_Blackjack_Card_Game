using System;
using System.Collections.Generic;

namespace Deck
{
    class Deck
    {
        //Attributes
        public List<Card> Cards;
        public Player P1;
        public Player Dealer;
        public int P1_Total;
        public int Dealer_Total;

        public Deck myDeck;

        //Constructor ------------------------------------
        public Deck()
        {
            Cards = new List<Card>();
            string[] suits = { "Hearts", "Clubs", "Spades", "Diamonds" };
            string[] stringVal = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
            int[] val = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };
            for (int i = 0; i < suits.Length; i++)
            {
                for (int v = 0; v < stringVal.Length; v++)
                {
                    Cards.Add(new Card(suits[i], stringVal[v], val[v]));
                }
            }
        }

        //Methods: ----------------------------------------------
        public void StartGame()
        {
            initGame();

            for (var i = 0; i < P1.Hand.Count; i++)
            {
                P1_Total += P1.Hand[i].val;
                if (P1_Total == 21)
                {
                    System.Console.WriteLine($"Blackjack! {P1.Name} wins");
                    //ADD CODE HERE FOR ENDING GAME
                }

            }

            for (var i = 0; i < Dealer.Hand.Count; i++)
            {
                Dealer_Total += Dealer.Hand[i].val;
                if (Dealer_Total == 21)
                {
                    System.Console.WriteLine($"Blackjack! {Dealer.Name} wins");
                    //ADD CODE HERE FOR ENDING GAME
                }

            }
            Game_Time();
            //code for HIT or STAND?------------------------
        }

        public void initGame()
        {
            P1_Total = 0;
            Dealer_Total = 0;
            Cards.Clear();
            // Cards = new List<Card>();

            System.Console.WriteLine("Name of player 1?");
            string input = System.Console.ReadLine();
            P1 = new Player(input);
            System.Console.WriteLine("");
            System.Console.WriteLine("Dealer is Ivan");
            System.Console.WriteLine("");
            Dealer = new Player("Dealer");

            myDeck = new Deck();
            myDeck.Shuffle();
            P1.Draw(myDeck);
            P1.Draw(myDeck);
            Dealer.Draw(myDeck);
            Dealer.Draw(myDeck);

            ShowHands();
            if (Dealer.Hand[0].stringVal == "Ace" && Dealer.Hand[1].val == 10)
            {
                System.Console.WriteLine($"You Lost! {Dealer.Name} wins");
                return;
            }
            if (Dealer.Hand[1].stringVal == "Ace" && Dealer.Hand[0].val == 10)
            {
                System.Console.WriteLine($"You Lost! {Dealer.Name} wins");
                return;
            }


        }

        public Card Deal()
        {
            Card topCard = Cards[0];
            Cards.RemoveAt(0);
            return topCard;
        }

        // public void Reset()
        // {
        //     Cards.Clear();
        //     Cards = new List<Card>();
        //     string[] suits = { "Hearts", "Clubs", "Spades", "Diamonds" };
        //     string[] stringVal = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };
        //     int[] val = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10 };
        //     for (int i = 0; i < suits.Length; i++)
        //     {
        //         for (int v = 0; v < stringVal.Length; v++)
        //         {
        //             Cards.Add(new Card(suits[i], stringVal[v], val[i]));
        //         }
        //     }
        // }


        public Card Hit()
        {
            Card topCard = Cards[0];
            Cards.RemoveAt(0);
            return topCard;
        }
        public void Shuffle()
        {
            Random rand = new Random();
            int n = Cards.Count;
            for (int i = 0; i < n; i++)
            {
                int r = i + rand.Next(n - i);
                Card t = Cards[r];
                Cards[r] = Cards[i];
                Cards[i] = t;
            }
        }

        public void Game_Time()
        {

            System.Console.WriteLine("");
            System.Console.WriteLine($"{P1.Name} total is: {P1_Total}");
            System.Console.WriteLine($"{Dealer.Name} total is: {Dealer_Total}");
            System.Console.WriteLine("Would you like to hit or stand? 1 FOR HIT , 2 FOR STAND");
            System.Console.WriteLine("");
            string input = System.Console.ReadLine();
            System.Console.WriteLine("");
            if (input == "1")
            {
                P1.Draw(myDeck);
                // Aces();
                P1_Total += P1.Hand[P1.Hand.Count - 1].val;
                if (P1_Total == 21)
                {
                    ShowHands();
                    System.Console.WriteLine($"{P1.Name} total is: {P1_Total}");
                    System.Console.WriteLine($"{Dealer.Name} total is: {Dealer_Total}");
                    System.Console.WriteLine($"Blackjack! {P1.Name} wins");
                    return;
                }
                else if (P1_Total > 21)
                {
                    ShowHands();

                    System.Console.WriteLine($"{P1.Name} total is: {P1_Total}");
                    System.Console.WriteLine($"{Dealer.Name} total is: {Dealer_Total}");
                    System.Console.WriteLine($"Bust! {Dealer.Name} wins");
                    return;
                }
            }


            if (input == "2") //STAND
            {

                if (P1_Total < Dealer_Total)
                {
                    ShowHands();
                    System.Console.WriteLine($"{P1.Name} total is: {P1_Total}");
                    System.Console.WriteLine($"{Dealer.Name} total is: {Dealer_Total}");
                    System.Console.WriteLine($"You Lost! {Dealer.Name} wins");
                    System.Console.WriteLine("You cannot stand if you have less than or equal to the Dealer's value.");
                    return;
                }

                if (P1_Total == Dealer_Total)
                {
                    DealerLoop();
                }

                Dealer.Draw(myDeck);
                Dealer_Total += Dealer.Hand[Dealer.Hand.Count - 1].val;

                if (Dealer_Total == 21)
                {
                    ShowHands();
                    System.Console.WriteLine($"{P1.Name} total is: {P1_Total}");
                    System.Console.WriteLine($"{Dealer.Name} total is: {Dealer_Total}");
                    System.Console.WriteLine($"Dealer Blackjack! {Dealer.Name} wins");
                    return;
                }

                else if (Dealer_Total > 21)
                {
                    ShowHands();
                    System.Console.WriteLine($"{P1.Name} total is: {P1_Total}");
                    System.Console.WriteLine($"{Dealer.Name} total is: {Dealer_Total}");
                    System.Console.WriteLine($"Dealer Busted! {P1.Name} wins");
                    return;
                }

                else if (Dealer_Total < 21)
                {
                    DealerLoop();
                    return;

                }

            }
            System.Console.WriteLine("");
            ShowHands();
            System.Console.WriteLine("");
            Game_Time();

        }

        // public void Aces()
        // {
        //     int sum = 0;
        //     int aceCount = 0;

        //     foreach (Card x in P1.Hand)
        //     {
        //         if (x.stringVal == "Ace")
        //         {
        //             aceCount++;
        //         }
        //     }

        // }
        public void DealerLoop()
        {
            Dealer.Draw(myDeck);
            Dealer_Total += Dealer.Hand[Dealer.Hand.Count - 1].val;
            if (Dealer_Total == 21)
            {
                ShowHands();
                System.Console.WriteLine($"{P1.Name} total is: {P1_Total}");
                System.Console.WriteLine($"{Dealer.Name} total is: {Dealer_Total}");
                System.Console.WriteLine($"Blackjack! {Dealer.Name} wins");
                return;
            }

            else if (Dealer_Total > 21)
            {
                ShowHands();
                System.Console.WriteLine($"{P1.Name} total is: {P1_Total}");
                System.Console.WriteLine($"{Dealer.Name} total is: {Dealer_Total}");
                System.Console.WriteLine($"Dealer Busted! {P1.Name} wins");
                return;
            }
            DealerLoop();
        }

        public void ShowHands()
        {
            System.Console.WriteLine($"{P1.Name}'s Hand: ");
            foreach (var i in P1.Hand)
            {
                System.Console.WriteLine(i.suit + " of " + i.stringVal);
            }
            System.Console.WriteLine("");
            System.Console.WriteLine($"{Dealer.Name}'s Hand: ");
            foreach (var i in Dealer.Hand)
            {
                System.Console.WriteLine(i.suit + " of " + i.stringVal);
            }
            System.Console.WriteLine("");
        }

    }
}

