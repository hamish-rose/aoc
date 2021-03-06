using System.Collections.Generic;
using System.Linq;
using Solutions.Util;
using Xunit;

namespace Solutions.Day2
{
    public class Day2Tests
    {
        [Theory]
        [InlineData("1-1 a", "kiwi", false)]
        [InlineData("1-1 i", "kiwi", false)]
        [InlineData("3-5 i", "kiwi", false)]
        [InlineData("1-2 i", "kiwi", true)]
        public void RuleValidation(string rule, string password, bool isValid)
        {
            Assert.Equal(isValid, Solution.IsValidPassword(rule, password));
        }

        [Fact]
        public void PuzzleSolution()
        {
            IEnumerable<string> input = FileUtilities.ReadLinesFromFile("./day2/input.txt");

            int count = input.Select(line => line.Split(':')
                    .Select(x => x.Trim())
                    .ToList())
                    .Count(inputs => Solution.IsValidPassword(inputs[0], inputs[1]));

            Assert.Equal(614, count);
        }
    }
}