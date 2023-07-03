using Microsoft.VisualStudio.TestTools.UnitTesting;
using J5S2EscapeRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace J5S2EscapeRoom.Tests
{
    [TestClass()]
    public class CombinationGeneratorTests
    {
        [TestMethod()]
        public void FindCombinationsTest()
        {
            int target = 12; // Replace with your desired integer value
            NewMethod(target);

            static void NewMethod(int target)
            {
                List<Tuple<int, int>> combinations = CombinationGenerator.FindCombinations(target);
                foreach (Tuple<int, int> combination in combinations)
                {
                    Console.WriteLine($"{combination.Item1} x {combination.Item2} = {target}");
                }
            }
            //Assert.Fail();
        }
    }
}