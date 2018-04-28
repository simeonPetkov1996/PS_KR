using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectYahtzee.Calculators
{
    public class FourOfAKindCalculator : ICombinationCalculator
    {
        public int Calculate(List<int> Values)
        {
            List<int> DistinctValues = Values.Distinct().ToList();

            foreach (int DistinctValue in DistinctValues)
            {
                if (Values.Count(x => x == DistinctValue) >= 4)
                {
                    return DistinctValue * 4;
                }
            }
            return 0;
        }
    }
}
