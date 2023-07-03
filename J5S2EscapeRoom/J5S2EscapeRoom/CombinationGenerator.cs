using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J5S2EscapeRoom
{
    public class CombinationGenerator
    {
        //Austin is good with math
        public static List<Tuple<int, int>> FindCombinations(int target)
        {
            List<Tuple<int, int>> combinations = new List<Tuple<int, int>>();

            for (int i = 1; i <= Math.Sqrt(target); i++)
            {
                if (target % i == 0)
                {
                    int divisor = target / i;
                    combinations.Add(new Tuple<int, int>(i, divisor));
                    if (i != divisor)
                    {
                        combinations.Add(new Tuple<int, int>(divisor, i));
                    }
                }
            }

            return combinations;
        }
    }
}
