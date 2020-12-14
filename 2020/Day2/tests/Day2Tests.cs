using System.Collections.Generic;
using System.Linq;
using Day2;
using Util;
using Xunit;

namespace Day2Tests
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
          Assert.Equal(isValid,Solution.IsValidPassword(rule, password));
        }

        [Fact]
        public void PuzzleSolution()
        {
            IEnumerable<string> input = FileUtilities.ReadLinesFromFile("input.txt");

            int count = 0;
            
            foreach (string line in input)
            {
                List<string> inputs = line.Split(':')
                    .Select(x => x.Trim())
                    .ToList();

                if (Solution.IsValidPassword(inputs[0], inputs[1]))
                {
                    count++;
                }
            }
            
            Assert.Equal(614, count);
        }
    }
}