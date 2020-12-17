using System.Collections.Generic;
using Solutions.Util;
using Xunit;

namespace Solutions.Day4
{
    public class Tests
    {
        [Fact]
        public void PuzzleTests()
        {            
            IEnumerable<string> input = FileUtilities.ReadLinesFromFile("./day4/input.txt");
            (int present, int valid) results = Solution.CountValidPassports(input);

            Assert.Equal(170,results.present);
        }

        [Fact]
        public void PuzzleTestsPart2()
        {
            IEnumerable<string> input = FileUtilities.ReadLinesFromFile("./day4/input.txt");
            (int present, int valid) results = Solution.CountValidPassports(input);

            Assert.Equal(0,results.valid);
        }
    }
}