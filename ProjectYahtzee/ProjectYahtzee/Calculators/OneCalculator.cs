using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectYahtzee.Calculators
{
    public class OneCalculator : AbstractSingleValueCalculator
    {
        public override int Calculate(List<int> values)
        {
            return CalculateForNumber(values, 1);
        }
    }
}
