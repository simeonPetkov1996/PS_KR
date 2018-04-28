using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectYahtzee.Calculators
{
    public class ThreeOfAKindCalculator : ICombinationCalculator
    {
        public int Calculate(List<int> Values)
        {
            List<int> DistinctValues = Values.Distinct().ToList();

            foreach (int DistinctValue in DistinctValues)
            {
                if (Values.Count(x => x == DistinctValue) >= 3)
                {
                    return DistinctValue * 3;
                }
            }
            return 0;
        }
    }
}
