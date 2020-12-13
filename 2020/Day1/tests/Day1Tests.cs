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
            List<int> input = Util.FileUtilities.ReadIntsFromFile("input.txt")
                .ToList();
            var result = Solution.FindPairWithSum(input, 2020);
            Assert.Equal((1162, 858), result);
        }
    }
}