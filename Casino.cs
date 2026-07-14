using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batman
{
    public static class Casino
    {
        public static void PlayBlackjack()
        {
            Console.Clear();
            Console.WriteLine(" Witaj w Blackjacku! Cel: pokonaj krupiera, nie przekraczając 21.");

            List<Card> deck = GenerateDeck();
            ShuffleDeck(deck);

            List<Card> playerHand = new();
            List<Card> dealerHand = new();

            playerHand.Add(DrawCard(deck));
            playerHand.Add(DrawCard(deck));
            dealerHand.Add(DrawCard(deck));
            dealerHand.Add(DrawCard(deck));

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Twoje karty:");
                DisplayHand(playerHand);
                int playerScore = CalculatePoints(playerHand);
                Console.WriteLine($"Twój wynik: {playerScore}\n");

                Console.WriteLine("Karty krupiera:");
                Console.WriteLine($"[{dealerHand[0].Name}] [??]");

                if (playerScore == 21)
                {
                    Console.WriteLine("BLACKJACK! ");
                    break;
                }

                if (playerScore > 21)
                {
                    Console.WriteLine("Przegrałeś!  Przekroczyłeś 21.");
                    Console.WriteLine("\nNaciśnij Enter, aby wyjsc z kasyna...");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("\n1. Dobierz kartę\n2. Pas");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    playerHand.Add(DrawCard(deck));
                }
                else if (choice == "2")
                {
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine("Karty krupiera:");
            DisplayHand(dealerHand);

            int dealerScore = CalculatePoints(dealerHand);
            while (dealerScore < 17)
            {
                dealerHand.Add(DrawCard(deck));
                dealerScore = CalculatePoints(dealerHand);
                Console.WriteLine("Krupier dobiera kartę...");
                Thread.Sleep(1000);
                DisplayHand(dealerHand);
            }

            int playerTotal = CalculatePoints(playerHand);
            dealerScore = CalculatePoints(dealerHand);

            Console.WriteLine($"\nTwój wynik: {playerTotal}");
            Console.WriteLine($"Wynik krupiera: {dealerScore}");

            if (dealerScore > 21 || playerTotal > dealerScore)
            {
                Console.WriteLine(" WYGRAŁEŚ!");
            }
            else if (dealerScore == playerTotal)
            {
                Console.WriteLine(" REMIS!");
            }
            else
            {
                Console.WriteLine( "PRZEGRAŁEŚ.");
            }

            Console.WriteLine("\nNaciśnij Enter, aby wyjsc z kasyna...");
            Console.ReadLine();
        }
        public static List<Card> GenerateDeck()
        {
            List<Card> deck = new();

            string[] figures = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            foreach (var f in figures)
            {
                int value = f switch
                {
                    "J" or "Q" or "K" => 10,
                    "A" => 11,
                    _ => int.Parse(f)
                };

                for (int i = 0; i < 4; i++) // 4 kolory
                    deck.Add(new Card(f, value));
            }

            return deck;
        }

        public static void ShuffleDeck(List<Card> deck)
        {
            Random rng = new();
            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (deck[k], deck[n]) = (deck[n], deck[k]);
            }
        }

        public static Card DrawCard(List<Card> deck)
        {
            Card card = deck[0];
            deck.RemoveAt(0);
            return card;
        }

        public static int CalculatePoints(List<Card> cards)
        {
            int sum = 0;
            int aces = 0;

            foreach (var card in cards)
            {
                if (card.Name == "A")
                {
                    aces++;
                    sum += 11;
                }
                else
                {
                    sum += card.Value;
                }
            }

            while (sum > 21 && aces > 0)
            {
                sum -= 10;
                aces--;
            }

            return sum;
        }

        public static void DisplayHand(List<Card> hand)
        {
            foreach (var card in hand)
            {
                Console.Write($"[{card.Name}] ");
            }
            Console.WriteLine();
        }



    }
}
