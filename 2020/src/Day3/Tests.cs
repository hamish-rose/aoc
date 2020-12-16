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

            int result = Solution.CountTreesOnPath(input, 3, 1);
            Assert.Equal(282, result);
        }

        [Fact]
        public void PuzzlePart2Tests()
        {
            string[] input = FileUtilities.ReadLinesFromFile("./day3/input.txt").ToArray();

            int a = Solution.CountTreesOnPath(input, 1, 1);
            int b = Solution.CountTreesOnPath(input, 3, 1);
            int c = Solution.CountTreesOnPath(input, 5, 1);
            int d = Solution.CountTreesOnPath(input, 7, 1);
            int e = Solution.CountTreesOnPath(input, 1, 2);
            
            Assert.Equal(1, a*b*c*d*e);
        }
    }
}