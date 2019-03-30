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
        }

        public void GetRank()
        {
            if (IsFiveOfAKind())
            {
                Rank = new Rank(Ranks.FiveOfAKind);
            }
            else if (IsStraightFlush())
            {
                Rank = new Rank(Ranks.StraightFlush);
            }
            else
            {
                Rank = new Rank(Ranks.TwoPair);
            }
        }

        private bool IsFiveOfAKind()
        {
            var cards = (from c in Cards
                         group c by c.CardName.ToLower() into d
                         select new
                         {
                             CardName = d.Key,
                             NumberOfKey = d.Count()
                         }).ToList();
            if ((cards.Count == 2) &&
                (cards[0].NumberOfKey == 4 || cards[1].NumberOfKey == 4) &&
                (cards[0].CardName.ToLower() == "joker" || cards[1].CardName.ToLower() == "joker"))
            {
                return true;
            }
            return false;
        }

        private bool IsStraightFlush()
        {
            var cards = (from c in Cards
                         orderby c.CardValue
                         select c).ToList();

            var cardClasses = (from c in Cards
                               group c by c.CardClass into d
                               select new
                               {
                                   CardClassCount = d.Count()
                               }).ToList();

            if(cardClasses.Count > 1)
            {
                return false;
            }

            if (((cards[0].CardValue + 1 == cards[1].CardValue) &&
                (cards[0].CardValue + 2 == cards[2].CardValue) &&
                (cards[0].CardValue + 3 == cards[3].CardValue) &&
                (cards[0].CardValue + 4 == cards[4].CardValue)))
            {
                return true;
            }

            return false;
        }
    }
}