using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectYahtzee.Calculators
{
    public class LargeStraightCalculator : ICombinationCalculator
    {
        public int Calculate(List<int> Values)
        {
            Values.Sort();
            List<int> DistinctValues = Values.Distinct().ToList();
            if(DistinctValues.Count() == 5)
            {
                if(DistinctValues[DistinctValues.Count()-1] - DistinctValues[0] < 5)
                {
                    return 30;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
            
    }
}
