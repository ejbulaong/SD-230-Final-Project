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
            if (deck.Hands.Count < 1)
            {
                Console.WriteLine("Sorry. No hand/s to evaluate!");
            }
            else
            {
                var handValues = new List<int>() { };
                foreach (var hand in deck.Hands)
                {
                    var screenOutput = $"{hand.PlayerName} ";
                    foreach (var card in hand.Cards)
                    {
                        screenOutput += card.CardName + " ";
                    }
                    handValues.Add(hand.Rank.Value);
                    Console.WriteLine(screenOutput);
                }

                var winningHandValue = handValues.Max();
                var winningHands = (from h in deck.Hands
                                    where h.Rank.Value == winningHandValue
                                    select h).ToList();

                Console.WriteLine("Winner/s");

                foreach (var hand in winningHands)
                {
                    Console.WriteLine(hand.PlayerName + " "+ hand.Rank.Name);
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
            var cardsFirstChar = new List<string>();

            for (var x = 0; x < 5; x++)
            {
                var cardInput = "";
                Console.Write($"Please enter card{x + 1}: ");
                cardInput = Console.ReadLine();
                Console.WriteLine();  

                if (x == 4 && cardInput.Substring(0,1).ToLower() == cardsFirstChar[3].ToLower() &&
                    ((cardsFirstChar[0].ToLower() == cardsFirstChar[1].ToLower()) &&
                    (cardsFirstChar[0].ToLower() == cardsFirstChar[2].ToLower()) &&
                    (cardsFirstChar[2].ToLower() == cardsFirstChar[3].ToLower())))
                {

                    Console.WriteLine("Cannot have five similar cards.");
                    --x;
                }
                else if (allowedHand.Contains(cardInput.ToUpper()))
                {
                    var newCard = new Card(cardInput);
                    newHand.Cards.Add(newCard);
                    cardsFirstChar.Add(newCard.CardName.Substring(0,1));
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