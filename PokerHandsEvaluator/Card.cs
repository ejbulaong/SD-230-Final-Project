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
            CardClass = getClassValue();
            CardValue = getCardValue();
        }

        private CardClass getClassValue()
        {
            var firstChar = CardName.Substring(1, 1);
            if (firstChar == "C")
            {
                return CardClass.Club;
            }
            else if (firstChar == "S")
            {
                return CardClass.Spade;
            }
            else if (firstChar == "H")
            {
                return CardClass.Heart;
            }
            else if (firstChar == "D")
            {
                return CardClass.Diamond;
            }
            else
            {
                return CardClass.Joker;
            }
        }

        private int getCardValue()
        {
            var firstChar = CardName.Substring(1, 1);
            var cardValues = new List<int>() { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            var cardFirstNames = new List<string>() { "A", "K", "Q", "J", "9", "8", "7", "6", "5", "4", "3", "2" };

            var cardValue = (from f in cardFirstNames
                             where f == CardName.Substring(1, 1)
                             select f).FirstOrDefault();

            return cardFirstNames.IndexOf(cardValue);           
        }
    }
}
