using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectYahtzee
{
    public interface ICombinationCalculator
    {
        int Calculate(List<int> values);
    }
}
