using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Solutions.Day1
{
    public class Tests
    {
        [Fact]
        public void PuzzleTest()
        {
            int sum = 2020;
            List<int> input = Util.FileUtilities.ReadIntsFromFile("./day1/input.txt")
                .ToList();
            var result = Solution.FindPairWithSum(input,sum);
            Assert.Equal(sum, result.Item1 + result.Item2);
        }
    }
}