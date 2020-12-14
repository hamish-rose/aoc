using System.Collections.Generic;
using System.Linq;
using Day1;
using Xunit;

namespace Day1Tests
{
    public class Day1Tests
    {
        [Fact]
        public void PuzzleTest()
        {
            int sum = 2020;
            List<int> input = Util.FileUtilities.ReadIntsFromFile("input.txt")
                .ToList();
            var result = Solution.FindPairWithSum(input,sum);
            Assert.Equal(sum, result.Item1 + result.Item2);
        }
    }
}