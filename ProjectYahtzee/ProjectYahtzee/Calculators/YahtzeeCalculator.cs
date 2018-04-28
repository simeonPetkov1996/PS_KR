using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectYahtzee.Calculators
{
    public class YahtzeeCalculator : ICombinationCalculator
    {
        public int Calculate(List<int> Values)
        {
            List<int> DistinctValues = Values.Distinct().ToList();
            if(DistinctValues.Count() == 1)
            {
                return 50;
            }
            else
            {
                return 0;
            }
        }
            
    }
}
