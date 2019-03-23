using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandsEvaluator
{
    public class Hand
    {
        public string PlayerName { get; set; }
        public List<Card> Cards { get; set; }
        public Rank Rank { get; set; }
        public int Value { get; set; }

        public Hand()
        {
            Cards = new List<Card>();
            Rank = GetRank();
        }

        private Rank GetRank()
        {

            var fiveOfAKind = Cards.GroupBy(c => c.CardName)
                .Where(c => c.Count() > 3)
                .Select(c => c)
                .ToList();

            if (fiveOfAKind != null)
            {
                return Rank.FiveOfAKind;
            }
            return Rank.FiveOfAKind;
        }
    }
}
