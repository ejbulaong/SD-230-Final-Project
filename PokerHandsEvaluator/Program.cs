using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandsEvaluator
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();

            var input = "";

            while (input != "0")
            {
                Console.WriteLine("Please choose an option:");
                Console.WriteLine("1 - Enter a poker's hand");
                Console.WriteLine("2 - Evaluate");
                Console.WriteLine("0 - Exit");

                input = Console.ReadLine();

                if (input == "1")
                {
                    AddHand(deck);
                }
                else if (input == "2")
                {
                    Evaluate(deck);
                }
            }
        }

        private static void Evaluate(Deck deck)
        {
            if(deck.Hands.Count < 1)
            {
                Console.WriteLine("Sorry. No hand/s to evaluate!");
            }
            else
            {
                foreach (var hand in deck.Hands)
                {
                    var screenOutput = $"{hand.PlayerName} ";
                    foreach (var card in hand.Cards)
                    {
                        screenOutput += card.CardName + " ";
                    }
                    Console.WriteLine(screenOutput + " " + hand.Rank.Name);
                }
            }            
        }

        private static void AddHand(Deck deck)
        {
            var playerName = "";
            var allowedHand = new List<string>();
            var newHand = new Hand();
            foreach (var card in deck.Cards)
            {
                allowedHand.Add(card.CardName);
            }

            Console.Write("Please enter player's name: ");
            playerName = Console.ReadLine();
            newHand.PlayerName = playerName;
            Console.WriteLine();

            for (var x = 0; x < 5; x++)
            {
                var cardInput = "";
                Console.Write($"Please enter card{x + 1}: ");
                cardInput = Console.ReadLine();
                Console.WriteLine();

                if (x == 4 && cardInput.ToLower() == newHand.Cards[3].CardName.ToLower() &&
                    ((newHand.Cards[0].CardName.ToLower() == newHand.Cards[1].CardName.ToLower()) &&
                    (newHand.Cards[1].CardName.ToLower() == newHand.Cards[2].CardName.ToLower()) &&
                    (newHand.Cards[2].CardName.ToLower() == newHand.Cards[3].CardName.ToLower())))
                {

                    Console.WriteLine("Cannot have five similar cards.");
                    --x;
                }
                else if (allowedHand.Contains(cardInput.ToUpper()))
                {
                    var newCard = new Card(cardInput);
                    newHand.Cards.Add(newCard);
                }
                else
                {
                    Console.WriteLine("Sorry. Not a valid card.");
                    --x;
                }
            }
            Console.WriteLine("Player's hand successfully saved!");
            newHand.GetRank();
            deck.Hands.Add(newHand);
        }
    }
}