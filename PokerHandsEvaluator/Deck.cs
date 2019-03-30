using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandsEvaluator
{
    public class Deck
    {
        public List<Card> Cards { get; set; }
        public List<Hand> Hands { get; set; }

        public Deck()
        {
            Cards = new List<Card>();
            Hands = new List<Hand>();
            GenerateCards();
        }

        private void GenerateCards()
        {
            var cardFirstNames = new List<string>() { "A", "K", "Q", "J", "10", "9", "8", "7", "6", "5", "4", "3", "2" };
            var cardNames = new List<CardName>() {
                CardName.Ace,CardName.King,CardName.Queen,CardName.Jack,CardName.Ten,CardName.Nine,CardName.Eigth,
                CardName.Seven,CardName.Six,CardName.Five,CardName.Four,CardName.Three,CardName.Two
            };

            var cardClasses = new List<CardClass>() {
                CardClass.Club, CardClass.Spade,CardClass.Heart,CardClass.Diamond
            };

            foreach (var c in cardClasses)
            {
                for (var x = 0; x < cardNames.Count(); x++)
                {
                    var newCard = new Card(cardFirstNames[x] + c.ToString().Substring(0, 1));
                    Cards.Add(newCard);
                }
            }

            var joker = new Card("JOKER");
            Cards.Add(joker);
        }
    }
}
