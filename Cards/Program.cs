using System;

namespace Cards
{
    class Program
	{
        public static void Main(string[] args)
        {
            Console.WriteLine("Quick & Dirty Card App");
            var deck = new Deck();
            ConsoleLog("=== INIT & PRINT ===");
            deck.Create();
            deck.Print();
            ConsoleLog("=== SHUFFLE & PRINT ===");
            deck.Shuffle();
            deck.Print();
            ConsoleLog("=== DEAL ONE CARD & PRINT ===");
            ConsoleLog(deck.DealOneCard().ToString());

            try
            {
                deck.DealAllCards();
            }
            catch (Exception ex)
            {
                ConsoleLog(ex.ToString());
            }
            
        }

        private static void ConsoleLog(string data)
        {
            Console.WriteLine(data);
        }
    }

    public class Deck
    {
        //Simple setup with string arrays
        public string[] cards = new string[52];
        public static string[] suits = { "Clubs", "Diamonds", "Hearts", "Spades" };
        public static string[] ranks = { "Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King" };

        //Initialize the deck of 52 playing cards
        public void Create()
        {
            int cardCount = 0;
            for (var suit = 0; suit < suits.Length; suit++)
            {
                for (var rank = 0; rank < ranks.Length; rank++)
                {
                    var card = ranks[rank] + " of " + suits[suit];
                    cards[cardCount] = card;
                    cardCount++;
                }
            }
        }

        public void Shuffle()
        {
            //Fisher Yates background algorithm
            var random = new System.Random();
            var numberOfCards = cards.Length;

            for (var i = 0; i < numberOfCards; i++)
            {
                var r = i + random.Next(numberOfCards - i);
                var card = cards[r];
                cards[r] = cards[i];
                cards[i] = card;
            }
        }

        public string DealOneCard()
        {
            //Assuming the top card, face-side down, is [0], we take one card
            //Console.WriteLine(cards[0]);
            return cards[0];
        }

        //This will be implemented later
        public void DealAllCards()
        {
            throw new NotImplementedException();
        }

        //Utility method
        public void Print()
        {
            foreach (var card in cards)
                Console.WriteLine(card);
        }
    }
}
