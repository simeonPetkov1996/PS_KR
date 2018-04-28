using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectYahtzee.Calculators
{
    public abstract class AbstractSingleValueCalculator : ICombinationCalculator
    {
        public abstract int Calculate(List<int> values);

        protected int CalculateForNumber(List<int> values, int number)
        {
            int result = 0;
            foreach(int value in values){
                if(value == number)
                {
                    result += value;
                }
            }
            return result;
        }
    }
}
