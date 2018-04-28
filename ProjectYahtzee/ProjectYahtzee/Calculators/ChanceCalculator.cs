using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectYahtzee.Calculators
{
    public class ChanceCalculator : ICombinationCalculator
    {
        public int Calculate(List<int> Values)
        {
            int Result = 0;
            foreach(int Value in Values)
            {
                Result += Value;
            }
            return Result;
        }
            
    }
}
