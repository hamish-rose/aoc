using System;
using System.Collections.Generic;

namespace Day1
{
    public static class Solution
    {
        /// <summary>
        /// Searches the input for two integers with a sum equal to <param name="sum"></param>
        /// </summary>
        /// <param name="input"> find values in this collection</param>
        /// <param name="sum"> find values with a sum equal to this.</param>
        /// <returns> the two values</returns>
        /// <exception cref="InvalidOperationException"> thrown if no match.</exception>
        public static (int, int) FindPairWithSum(List<int> input, int sum)
        {
            input.Sort();
            input.Reverse();
            
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input.Count; j++)
                {
                    int reverseIndex = input.Count - 1 - j;
                    int localSum = input[i] + input[reverseIndex];

                    if (localSum > sum)
                    {
                        break;
                    }
                    else if (localSum == sum)
                    {
                        return (input[i], input[reverseIndex]);
                    }
                }
            }

            throw new InvalidOperationException($"No pair with a sum of {sum} found");
        }
    }
}