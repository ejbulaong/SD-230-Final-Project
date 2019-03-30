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
            else if (IsFourOfAKind())
            {
                Rank = new Rank(Ranks.FourOfAKind);
            }
            else if (IsFullHouse())
            {
                Rank = new Rank(Ranks.FullHouse);
            }
            else if (IsFlush())
            {
                Rank = new Rank(Ranks.Flush);
            }
            else if (IsStraight())
            {
                Rank = new Rank(Ranks.Straight);
            }
            else if (IsThreeOfAKind())
            {
                Rank = new Rank(Ranks.ThreeOfAKind);
            }
            else if (IsTwoPair())
            {
                Rank = new Rank(Ranks.TwoPair);
            }
            else if (IsOnePair())
            {
                Rank = new Rank(Ranks.OnePair);
            }
            else if (IsHighCard())
            {
                Rank = new Rank(Ranks.HighCard);
            }
            else
            {
                throw new Exception("Unhandled Rank");
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

            var cardValues = (from c in Cards
                         group c by c.CardValue into d
                         select new
                         {
                             NumberOfKey = d.Count()
                         }).ToList();

            if ((cardValues.Count == 2) &&
                (cardValues[0].NumberOfKey == 4 || cardValues[1].NumberOfKey == 4) &&
                (cards[0].CardName.ToLower() == "joker" || cards[1].CardName.ToLower() == "joker" ||
                cards[2].CardName.ToLower() == "joker" || cards[3].CardName.ToLower() == "joker" || 
                cards[4].CardName.ToLower() == "joker"))
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

            if (cardClasses.Count > 1)
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

        private bool IsFourOfAKind()
        {
            var cards = (from c in Cards
                         group c by c.CardName.ToLower() into d
                         select new
                         {
                             CardName = d.Key,
                             NumberOfKey = d.Count()
                         }).ToList();

            var cardValues = (from c in Cards
                         group c by c.CardValue into d
                         select new
                         {
                             NumberOfKey = d.Count()
                         }).ToList();

            if ((cardValues.Count == 2) &&
                (cardValues[0].NumberOfKey == 4 || cardValues[1].NumberOfKey == 4) &&
                (cards[0].CardName.ToLower() != "joker" || cards[1].CardName.ToLower() != "joker"))
            {
                return true;
            }

            return false;
        }

        private bool IsFullHouse()
        {
            var cards = (from c in Cards
                         group c by c.CardValue into d
                         select new
                         {
                             NumberOfKey = d.Count()
                         }).ToList();

            if ((cards.Count == 2) &&
                ((cards[0].NumberOfKey == 3 && cards[1].NumberOfKey == 2) ||
                (cards[0].NumberOfKey == 2 || cards[1].NumberOfKey == 3)))
            {
                return true;
            }

            return false;
        }

        private bool IsFlush()
        {
            var cards = (from c in Cards
                         group c by c.CardClass into d
                         select new
                         {
                             CardName = d.Key,
                             NumberOfKey = d.Count()
                         }).ToList();

            if(cards.Count == 1)
            {
                return true;
            }

            return false;
        }

        private bool IsStraight()
        {
            var cards = (from c in Cards
                         orderby c.CardValue
                         select c).ToList();

            if (((cards[0].CardValue + 1 == cards[1].CardValue) &&
                (cards[0].CardValue + 2 == cards[2].CardValue) &&
                (cards[0].CardValue + 3 == cards[3].CardValue) &&
                (cards[0].CardValue + 4 == cards[4].CardValue)))
            {
                return true;
            }

            return false;
        }

        private bool IsThreeOfAKind()
        {
            var cards = (from c in Cards
                         group c by c.CardValue into d
                         select new
                         {
                             CardName = d.Key,
                             NumberOfKey = d.Count()
                         }).ToList();

            if ((cards.Count == 3) &&
                (cards[0].NumberOfKey == 3 || cards[1].NumberOfKey == 3) || cards[2].NumberOfKey == 3)
            {
                return true;
            }

            return false;
        }

        private bool IsTwoPair()
        {
            var cards = (from c in Cards
                         group c by c.CardValue into d
                         select new
                         {
                             CardName = d.Key,
                             NumberOfKey = d.Count()
                         }).ToList();

            if (cards.Count == 3) 
            {
                return true;
            }

            return false;
        }

        private bool IsOnePair()
        {
            var cards = (from c in Cards
                         group c by c.CardValue into d
                         select new
                         {
                             CardName = d.Key,
                             NumberOfKey = d.Count()
                         }).ToList();

            if (cards.Count == 4)
            {
                return true;
            }

            return false;
        }

        private bool IsHighCard()
        {
            var cards = (from c in Cards
                         group c by c.CardValue into d
                         select new
                         {
                             CardName = d.Key,
                             NumberOfKey = d.Count()
                         }).ToList();

            if (cards.Count == 5)
            {
                return true;
            }

            return false;
        }
    }
}