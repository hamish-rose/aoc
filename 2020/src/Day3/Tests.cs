using System.Linq;
using Solutions.Util;
using Xunit;

namespace Solutions.Day3
{
    public class Tests
    {
        [Fact]
        public void PuzzleTests()
        {
            string[] input = FileUtilities.ReadLinesFromFile("./day3/input.txt").ToArray();

            int result = Solution.CountTreesOnPath(input);
            Assert.NotEqual(282, result);
        }
    }
}