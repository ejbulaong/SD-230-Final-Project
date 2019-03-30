using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandsEvaluator
{
    public class Rank
    {
        public Ranks Name { get; set; }
        public int Value { get; set; }

        public Rank(Ranks name)
        {
            Name = name;
        }
    }
}
