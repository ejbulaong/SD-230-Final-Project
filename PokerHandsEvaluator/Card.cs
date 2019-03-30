using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandsEvaluator
{
    public class Card
    {
        public string CardName { get; set; }
        public CardClass CardClass { get; set; }
        public int CardValue { get; set; }

        public Card(string cardName)
        {
            CardName = cardName;
            CardClass = GetClassValue();
            CardValue = GetCardValue();
        }

        private CardClass GetClassValue()
        {
            var lastChar = CardName.Substring(CardName.Length-1, 1).ToUpper();

            if (lastChar == "C")
            {
                return CardClass.Club;
            }
            else if (lastChar == "S")
            {
                return CardClass.Spade;
            }
            else if (lastChar == "H")
            {
                return CardClass.Heart;
            }
            else if (lastChar == "D")
            {
                return CardClass.Diamond;
            }
            else
            {
                return CardClass.Joker;
            }
        }

        private int GetCardValue()
        {
            var firstChar = CardName.Substring(0, 1).ToUpper();
            var cardValues = new List<int>() { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            var cardFirstNames = new List<string>() { "A", "K", "Q", "J", "9", "8", "7", "6", "5", "4", "3", "2" };

            var cardValue = (from f in cardFirstNames
                             where f == firstChar
                             select f).FirstOrDefault();

            return cardValues[cardFirstNames.IndexOf(cardValue)];           
        }
    }
}
