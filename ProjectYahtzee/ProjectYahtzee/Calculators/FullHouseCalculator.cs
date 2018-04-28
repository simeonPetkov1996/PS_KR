using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectYahtzee.Calculators
{
    public class FullHouseCalculator : ICombinationCalculator
    {
        public int Calculate(List<int> Values)
        {
            List<int> DistinctValues = Values.Distinct().ToList();

            if (DistinctValues.Count() != 2)
            {
                return 0;
            }
            else
            {
                if (Values.Count(x => x == DistinctValues[0]) == 3 && Values.Count(x => x == DistinctValues[1]) == 2)
                {
                    return 25;
                }
                if (Values.Count(x => x == DistinctValues[1]) == 3 && Values.Count(x => x == DistinctValues[0]) == 2)
                {
                    return 25;
                }
                return 0;
            }
        }
    }
}
